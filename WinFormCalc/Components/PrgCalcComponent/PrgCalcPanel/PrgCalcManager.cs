using System;
using System.Collections.Generic;
using System.Linq;
using WinFormCalc.Calculators.GoniometricFunctions.Enums;
using WinFormCalc.Calculators.PrgCalculator;
using WinFormCalc.Components.PrgCalcComponent.PrgCalcFunctionPanel;
using WinFormCalc.Components.PrgCalcComponent.PrgCalcKeyboard;
using WinFormCalc.Components.PrgCalcComponent.PrgCalcModal;
using WinFormCalc.Operations.PrimeOperations.PrgPrimeOper;

namespace WinFormCalc.Components.PrgCalcComponent.PrgCalcPanel;

public class PrgCalcManager
{

    private List<List<List<PrgNumber>>> numbers;

    private int depth;

    private int bracket;

    private VarType numberType;
        
    private string example;

    private string number;

    private PrgPrimeOper primeOper;

    private bool isCalculated;

    private bool isBracketClose;

    private readonly List<int> numberTypeNames;

    public delegate void ExampleLabelUpdate(string message);

    public event ExampleLabelUpdate OnExampleLabelUpdate;

    public delegate void NumberLabelUpdate(string message);

    public event NumberLabelUpdate OnNumberLabelUpdate;

    public delegate void NumberTypeButtonUpdate(string message);

    public event NumberTypeButtonUpdate OnNumberTypeButtonUpdate;


    public PrgCalcManager()
    {
        Init();
            
        ClearExample();
        ClearNumber();

        numberType = VarType.Dec;
        ChangeNumberType();

        isCalculated = false;
        isBracketClose = false;

        numberTypeNames = new((int[])Enum.GetValues(typeof(VarType)));
    }


    private void Init()
    {
        PrgCalcKeyboardEvents.OnNumpadButtonClick += NumpadButtonClick;
        PrgCalcKeyboardEvents.OnPlusButtonClick += PlusButtonClick;
        PrgCalcKeyboardEvents.OnMinusButtonClick += MinusButtonClick;
        PrgCalcKeyboardEvents.OnMultiplyButtonClick += MultiplyButtonClick;
        PrgCalcKeyboardEvents.OnDivideButtonClick += DivideButtonClick;
        PrgCalcKeyboardEvents.OnModuloButtonClick += ModuloButtonClick;
        PrgCalcKeyboardEvents.OnLeftShiftButtonClick += LeftShiftButtonClick;
        PrgCalcKeyboardEvents.OnRightShiftButtonClick += RightShiftButtonClick;
        PrgCalcKeyboardEvents.OnOpenBracketButtonClick += OpenBracketButtonClick;
        PrgCalcKeyboardEvents.OnCloseBracketButtonClick += CloseBracketButtonClick;
        PrgCalcKeyboardEvents.OnCommaButtonClick += CommaButtonClick;
        PrgCalcKeyboardEvents.OnClearButtonClick += ClearButtonClick;
        PrgCalcKeyboardEvents.OnClearEntryButtonClick += ClearEntryButtonClick;
        PrgCalcKeyboardEvents.OnBackButtonClick += BackButtonClick;
        PrgCalcKeyboardEvents.OnEqualsButtonClick += EqualsButtonClick;

        PrgCalcFunctionPanelEvents.OnNumberTypeButtonClick += NumberTypeButtonClick;
        PrgCalcModalEvents.OnAndButtonClick += AndButtonClick;
        PrgCalcModalEvents.OnOrButtonClick += OrButtonClick;
        PrgCalcModalEvents.OnNandButtonClick += NandButtonClick;
        PrgCalcModalEvents.OnNorButtonClick += NorButtonClick;
        PrgCalcModalEvents.OnXorButtonClick += XorButtonClick;
        PrgCalcModalEvents.OnXnorButtonClick += XnorButtonClick;
    }


    private static readonly List<string> Operators = new() {
        "+",
        "-",
        "*",
        "/",
        "%",
        "<<",
        ">>",
        "AND",
        "OR",
        "NAND",
        "NOR",
        "XOR",
        "XNOR"
    };


    public void UpdateNumberLabel()
    {
        OnNumberLabelUpdate?.Invoke(number);
    }


    public void UpdateExampleLabel()
    {
        OnExampleLabelUpdate?.Invoke(example);
    }


    private void NumpadButtonClick(string placeholder)
    {
        if (isCalculated) {
            UpdateExampleLabel();
            isCalculated = false;
        }

        if (number == "0") {
            number = placeholder;
        }
        else {
            number += placeholder;
        }

        UpdateNumberLabel();
    }


    private void PlusButtonClick(string placeholder)
    {
        AddNextNumber(PrgPrimeOper.Plus);
    }


    private void MinusButtonClick(string placeholder)
    {
        AddNextNumber(PrgPrimeOper.Minus);
    }


    private void MultiplyButtonClick(string placeholder)
    {
        AddNextNumber(PrgPrimeOper.Multiply);
    }


    private void DivideButtonClick(string placeholder)
    {
        AddNextNumber(PrgPrimeOper.Divide);
    }

        
    private void ModuloButtonClick(string placeholder)
    {
        AddNextNumber(PrgPrimeOper.Modulo);
    }


    private void LeftShiftButtonClick(string placeholder)
    {
        AddNextNumber(PrgPrimeOper.LeftShift);
    }


    private void RightShiftButtonClick(string placeholder)
    {
        AddNextNumber(PrgPrimeOper.RightShift);
    }


    private void OpenBracketButtonClick(string placeholder)
    {
        numbers[depth][bracket].Add(new PrgNumber(primeOper));
        AddDepth();

        example += "(";
        UpdateExampleLabel();

        primeOper = PrgPrimeOper.Plus;
    }


    private void CloseBracketButtonClick(string placeholder)
    {
        if ( ! AddNumber() || depth - 1 < 0) {
            return;
        }

        depth--;
        bracket = numbers[depth].Count - 1;
        isBracketClose = true;

        example += ")";
        UpdateExampleLabel();

        ClearNumber();

        primeOper = PrgPrimeOper.Plus;
    }


    private void CommaButtonClick(string placeholder)
    {
        number += ',';
        UpdateNumberLabel();
    }


    private void ClearButtonClick(string placeholder)
    {
        ClearExample();
        ClearNumber();
    }


    private void ClearEntryButtonClick(string placeholder)
    {
        ClearNumber();
    }


    private void BackButtonClick(string placeholder)
    {
        if (number.Length == 1) {
            number = "0";
            UpdateNumberLabel();
                
            return;
        }
            
        number = number.Remove(number.Length - 1);
        UpdateNumberLabel();
    }


    private void EqualsButtonClick(string placeholder)
    {
        if ( ! AddNumber()) {
            return;
        }

        try {
            PrgCalculator calculator = new PrgCalculator(numbers, new PrgNumber(numberType));

            number = calculator.GetResult();
            UpdateNumberLabel();
            number = "0";

            example += " = ";
            UpdateExampleLabel();
            example = string.Empty;

            numbers = new() {
                new() {
                    new()
                }
            };

            primeOper = PrgPrimeOper.Plus;
            depth = 0;
            bracket = 0;
            isCalculated = true;
        }
        catch(Exception) {
            ClearExample();

            number = "Error";
            UpdateNumberLabel();
            number = "0";
        }
    }


    private void NumberTypeButtonClick(string placeholder)
    {
        ClearExample();

        try {
            long value = Convert.ToInt64(number, (int)numberType);
            NextNumberType();
            number = Convert.ToString(value, (int)numberType);

            UpdateNumberLabel();
            OnNumberTypeButtonUpdate?.Invoke(numberType.ToString());
            ChangeNumberType();
        }
        catch (Exception) {
            ClearNumber();
        }
    }


    private void AndButtonClick()
    {
        AddNextNumber(PrgPrimeOper.And);
    }


    private void OrButtonClick()
    {
        AddNextNumber(PrgPrimeOper.Or);
    }


    private void NandButtonClick()
    {
        AddNextNumber(PrgPrimeOper.Nand);
    }


    private void NorButtonClick()
    {
        AddNextNumber(PrgPrimeOper.Nor);
    }


    private void XorButtonClick()
    {
        AddNextNumber(PrgPrimeOper.Xor);
    }


    private void XnorButtonClick()
    {
        AddNextNumber(PrgPrimeOper.Xnor);
    }


    private void ClearNumber()
    {
        number = "0";
        UpdateNumberLabel();
    }


    private void ClearExample()
    {
        numbers = new() {
            new() {
                new()
            }
        };

        example = string.Empty;
        UpdateExampleLabel();
            
        primeOper = PrgPrimeOper.Plus;
        depth = 0;
        bracket = 0;
    }


    private void AddNextNumber(PrgPrimeOper nextPrimeOper)
    {
        if ( ! AddNumber()) {
            return;
        }

        primeOper = nextPrimeOper;

        example += " " + Operators[(int)nextPrimeOper] + " ";
        UpdateExampleLabel();

        ClearNumber();
    }


    private bool AddNumber()
    {
        if (isBracketClose) {
            isBracketClose = false;
            return true;
        }

        try {
            long value = Convert.ToInt64(number, (int)numberType);
            numbers[depth][bracket].Add(
                new PrgNumber(value, primeOper)
            );
            example += number;

            return true;
        }
        catch (Exception) {
            ClearNumber();
            return false;
        }
    }


    private void AddDepth()
    {
        depth++;
        if (depth == numbers.Count) {
            numbers.Add(new List<List<PrgNumber>>());
        }

        bracket = numbers[depth].Count;
        numbers[depth].Add(new List<PrgNumber>());
    }


    private string GetCloseBrackets(int count)
    {
        if (count == 0) {
            return string.Empty;
        }
            
        return Enumerable.Repeat(')', count).Aggregate(
            string.Empty,
            (total, next) => total + next
        );
    }


    private void ChangeNumberType()
    {
        //TODO:disable numpad buttons
    }


    private void NextNumberType()
    {
        int index = numberTypeNames.IndexOf((int)numberType);

        if (index == numberTypeNames.Count - 1) {
            numberType = (VarType)numberTypeNames[0];
            return;
        }
            
        numberType = (VarType)numberTypeNames[index + 1];
    }
}
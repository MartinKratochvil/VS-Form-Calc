using System;
using System.Globalization;
using WinFormCalc.Components.ConvertorComponent.ConvertorKeyboard;
using WinFormCalc.Convertors;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorPanel
{
    public class ConvertorManager<T> where T : Enum
    {

        private string inputNumber;

        private string outputNumber;

        private T inputType;

        private T outputType;

        private bool isConverted;

        public delegate void InputLabelUpdate(string message);

        public event InputLabelUpdate OnInputLabelUpdate;

        public delegate void OutputLabelUpdate(string message);

        public event OutputLabelUpdate OnOutputLabelUpdate;


        public ConvertorManager()
        {
            Init();
            Clear();
        }


        private void Init()
        {
            ConvertorKeyboardEvents.OnNumpadButtonClick += NumpadButtonClick;
            ConvertorKeyboardEvents.OnCommaButtonClick += CommaButtonClick;
            ConvertorKeyboardEvents.OnClearEntryButtonClick += ClearEntryButtonClick;
        }


        public void UpdateInputLabel()
        {
            OnInputLabelUpdate?.Invoke(inputNumber);
        }


        public void UpdateOutputLabel()
        {
            OnOutputLabelUpdate?.Invoke(outputNumber);
        }


        public void ChangeInputType(T type)
        {
            inputType = type;
            isConverted = false;
            Convert();
        }


        public void ChangeOutputType(T type)
        {
            outputType = type;
            isConverted = false;
            Convert();
        }


        public void Clear()
        {
            inputNumber = "0";
            outputNumber = "0";
            isConverted = true;

            UpdateInputLabel();
            UpdateOutputLabel();
        }


        private void NumpadButtonClick(string placeholder)
        {
            if (inputNumber == "0") {
                inputNumber = placeholder;
            }
            else {
                inputNumber += placeholder;
            }

            isConverted = false;
            UpdateInputLabel();
            Convert();
        }


        private void CommaButtonClick(string placeholder)
        {
            inputNumber += ',';
            UpdateInputLabel();
        }


        private void ClearEntryButtonClick(string placeholder)
        {
            Clear();
        }


        private void Convert()
        {
            if (isConverted) {
                UpdateOutputLabel();
                return;
            }

            if ( ! double.TryParse(inputNumber, out double num)) {
                Clear();
            }

            try {
                outputNumber = Convertor.Convert(num, inputType, outputType).ToString(CultureInfo.CurrentCulture);
            }
            catch (Exception) {
                Clear();
                OnOutputLabelUpdate?.Invoke("Error");

                return;
            }
            
            UpdateOutputLabel();
            isConverted = true;
        }
    }
}
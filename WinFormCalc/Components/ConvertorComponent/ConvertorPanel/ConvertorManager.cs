using WinFormCalc.Components.ConvertorComponent.ConvertorKeyboard;

namespace WinFormCalc.Components.ConvertorComponent.ConvertorPanel
{
    public class ConvertorManager
    {


        public ConvertorManager()
        {
            Init();
        }


        private void Init()
        {
            ConvertorKeyboardEvents.OnNumpadButtonClick += NumpadButtonClick;
            ConvertorKeyboardEvents.OnCommaButtonClick += CommaButtonClick;
            ConvertorKeyboardEvents.OnClearButtonClick += ClearButtonClick;
        }


        private void NumpadButtonClick(string placeholder)
        {
            
        }


        private void CommaButtonClick(string placeholder)
        {
            
        }


        private void ClearButtonClick(string placeholder)
        {
            
        }
    }
}
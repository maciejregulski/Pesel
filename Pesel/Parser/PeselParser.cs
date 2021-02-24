using System;
using Pesel.Model;

namespace Pesel.Parser
{
    public class PeselParser
    {
        private Action<int, PeselStruct>[] parserActions = null;

        public PeselParser()
        {
            this.parserActions = new Action<int, PeselStruct>[]
            {
                (int digit, PeselStruct model) => {model.Year = 10 * digit;},
                (int digit, PeselStruct model) => {model.Year += digit;},
                (int digit, PeselStruct model) => {model.Month = 10 * digit;},
                (int digit, PeselStruct model) => {model.Month +=  digit;},
                (int digit, PeselStruct model) => {model.Day = 10 * digit;},
                (int digit, PeselStruct model) => {model.Day +=  digit;},
                (int digit, PeselStruct model) => {model.Number = 1000 * digit;},
                (int digit, PeselStruct model) => {model.Number += 100 * digit;},
                (int digit, PeselStruct model) => {model.Number += 10 * digit;},
                (int digit, PeselStruct model) => {model.Number +=  digit;},
                (int digit, PeselStruct model) => {model.CheckSum =  digit;},
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pesel"></param>
        /// <returns></returns>
        private bool ValidatePesel(string pesel)
        {
            if (!string.IsNullOrEmpty(pesel))
            {
                if (pesel.Length == 11)
                {
                    return int.TryParse(pesel, out int result);
                }
            }
            return false;
        }

        public PeselStruct ParsePesel(string pesel)
        {
            PeselStruct model = new PeselStruct();

            if (ValidatePesel(pesel))
            {
                for (int i = 0; i < pesel.Length; i++)
                {
                    if (i < parserActions.Length)
                    {
                        this.parserActions[i](Utils.Utils.CharToDigit(pesel[i]), model);
                    }
                }
            }

            return model;
        }
    }
}

// See https://aka.ms/new-console-template for more information

namespace MemoryGameObj
{
    class Field
    {
        private char rowLetter;
        private int columnNumber;
        private bool isSet;
        private string fieldValue;
        public static int fieldNumber;
        private bool isDone;

        public Field(char row,int column,string valueF)
        {
            this.rowLetter = row;
            this.columnNumber = column;
            this.fieldValue = valueF;
            this.isSet = false;
            this.isDone = false;
            fieldNumber++;
        }
        public bool IsSet
        {
            get
            {
                if (this.isDone == true) this.isSet = true;
                return isSet;
            }
            set
            {
                isSet = value;
            }
        }
        public string FieldValue
        {
            get 
            {
                return fieldValue;
            }
            set
            {
                fieldValue = value;
            }
        }
        public char RowLetter
        {
            get
            {
                return rowLetter;
            }
            set
            {
                rowLetter = value;
            }
        }
        public int ColumnNumber
        {
            get 
            { 
                return columnNumber; 
            }
            set
            {
                columnNumber = value;
            }
        }
        public bool IsDone
        {
            get 
            { 
                return isDone; 
            }
            set 
            { 
                isDone = value; 
            }
        }
        public static bool FieldCompare(List<Field> fields, Field currentCheck)
        {
            foreach (Field fieldListElement in fields)
            {
                if (fieldListElement.fieldValue==currentCheck.fieldValue && fieldListElement.isDone==false && currentCheck.isDone==false && fieldListElement.rowLetter!=currentCheck.rowLetter||fieldListElement.columnNumber!=currentCheck.columnNumber&& fieldListElement.fieldValue == currentCheck.fieldValue && fieldListElement.isDone == false && currentCheck.isDone == false)//it's awful
                {
                    if (fieldListElement.isSet == true && currentCheck.isSet == true)
                    {
                        fieldListElement.isDone = true;
                        currentCheck.isDone = true;
                        return true;
                    }
                }
                fieldListElement.isSet = false;
                if (fieldListElement.fieldValue == currentCheck.fieldValue && fieldListElement.rowLetter == currentCheck.rowLetter && fieldListElement.columnNumber == currentCheck.columnNumber) fieldListElement.isSet = true;//awful solution to wrongly unflipping the word when foreach passes through the currently checked argument
            }
            currentCheck.isSet = true;
            return false;
        }
    }

}
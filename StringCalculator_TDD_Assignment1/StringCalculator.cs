
namespace StringCalculator_TDD_Assignment1
{
    public class StringCalculator
    {
        public int add_Count;
        string[] separators = new string[] { "%", "\n", ",", ";", "*" };

        public int Add(string input_str)
        {
            int count = GetCalledCount();
            int result = 0;
            if (string.IsNullOrEmpty(input_str))
                return 0;
            else if (input_str.StartsWith("//"))
            {
                // removing the backslash
                input_str = input_str.Substring(2);
                if (input_str.StartsWith('['))
                {
                    // getting the delimiters within [ ]
                    int startindex = input_str.IndexOf('[');
                    int endindex = input_str.IndexOf("]");
                    string delimiter = input_str.Substring(input_str.IndexOf('['), input_str.LastIndexOf("]"));

                    // getting substring which is after the delimiters and triming
                    input_str = input_str.Substring(input_str.LastIndexOf(']'), input_str.Length - input_str.LastIndexOf(']'));
                    input_str = input_str.Trim(']');

                    // finding/framing the delimiters
                    char[] chars = new char[] { '[', ']' };
                    var delimiter1 = delimiter.Split(chars, StringSplitOptions.RemoveEmptyEntries);
                    // adding new delimiters to the delimiter array
                    delimiter1 = delimiter1.Append("\n").ToArray();
                    delimiter1 = delimiter1.Append(",").ToArray();
                    delimiter1 = delimiter1.Append(";").ToArray();
                    // finding the rest of the string
                    var restof_str = input_str.Split(delimiter1, StringSplitOptions.RemoveEmptyEntries);
                    result = Adding_Elements(restof_str);
                }
                else
                {
                    string[] res_str = input_str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    result = Adding_Elements(res_str);
                }
            }
            else
            {
                string[] res_str = input_str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                result = Adding_Elements(res_str);
            }
            return result;            
        }

        public int Adding_Elements(string[] elements)
        {
            var number = elements.Select(int.Parse);
            int result;
            var negatives = number.Where(n => n < 0);
                if (negatives.Any())
                {
                    if (negatives.Count() == 1)
                        throw new Exception("Negatives are not allowed");
                    else
                        throw new Exception($"Negatives are not allowed : {string.Concat(negatives)}");
                }
                else
                {
                    var number1 = number.Where(n => n <= 1000);
                    result = number1.Sum();
                }
            return result;
        }
            
        public int GetCalledCount()
        {
            return this.add_Count++;
        }
    }
}


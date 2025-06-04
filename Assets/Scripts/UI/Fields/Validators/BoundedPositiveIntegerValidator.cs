using UnityEngine;
using System;
using TMPro;

namespace Assets.Scripts.UI.Fields.Validators
{
    /// <summary>
    /// EXample of a Custom Character Input Validator to only allow digits from 0 to 9.
    /// </summary>
    [Serializable]
    [CreateAssetMenu(fileName = "InputValidator - BoundedPositiveInt.asset", menuName = "TextMeshPro/Input Validators/BoundedPositiveInteger", order = 100)]
    public class BoundedPositiveIntegerValidator : TMP_InputValidator
    {
        public int MinValue;
        public int MaxValue;

        // Custom text input validation function
        public override char Validate(ref string text, ref int pos, char ch)
        {
            int intValue;

            if (!char.IsNumber(ch))
                return (char)0;

            if (!int.TryParse(text + ch, out intValue))
                return (char)0;

            if (intValue < MinValue)
            {
                text = MinValue.ToString();
                return (char)0;
            }
            else if (intValue > MaxValue)
            {
                text = MaxValue.ToString();
                return (char)0;
            }
            else
            {
                text += ch;
                pos += 1;
                return ch;
            }
        }
    }
}
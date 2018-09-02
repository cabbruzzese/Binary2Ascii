using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Binary2Ascii
{
    public class Converter
    {
        public const int ASCII_LENGTH = 7;
        public const int EASCII_LENGTH = 8;
        public static readonly char[] BINARY_CHARS = new char[] { '0', '1' };
        public static readonly char[] DELIMITER_CHARS = new char[] { ' ', '\n', '\t', ',' };

        public static bool IsBinary(string blob)
        {
            if (blob == null)
                return false;

            string noDelimters = RemoveDelimiters(blob);

            return noDelimters.All(c => BINARY_CHARS.Contains(c));
        }

        public static string RemoveDelimiters (string blob)
        {
            if (blob == null)
                return null;

            var blobArray = blob.Where(c => !DELIMITER_CHARS.Contains(c)).ToArray();
            return new string(blobArray);
        }

        public static string RemoveNonBinaryCharacters(string blob)
        {
            var blobArray = blob.Where(c => BINARY_CHARS.Contains(c)).ToArray();
            return new string(blobArray);
        }

        public static List<char> BlobToBytes(string blob, int charLength = ASCII_LENGTH)
        {
            List<char> bytes = new List<char>();

            if (blob == null)
                return bytes;

            if (blob.Length < charLength)
                return bytes;

            if (!IsBinary(blob))
                throw new ArgumentException("Binary blob is not binary", "blob");
            
            string str = RemoveDelimiters(blob);
            while (str.Length >= charLength)
            {
                string token = str.Substring(0, charLength);
                int value = Convert.ToInt32(token, 2);
                bytes.Add((char)value);

                str = str.Substring(charLength, str.Length - charLength);
            }

            return bytes;
        }

        public static List<char> StringToBytes(string str, int charLength = ASCII_LENGTH)
        {
            List<char> bytes = new List<char>();

            if (str == null)
                return bytes;

            return str.ToCharArray().ToList();
        }

        public static string BytesToBlob(List<char> bytes, string delimiter = "")
        {
            string blob = "";

            if (bytes == null)
                return blob;

            foreach (char c in bytes)
            {
                blob = blob + Convert.ToString(c, 2) + delimiter;
            }

            return blob;
        }

        public static string BytesToString(List<char> bytes)
        {
            if (bytes == null)
                throw new ArgumentException("Byte array cannot be null", "bytes");

            return new string(bytes.ToArray());
        }

    }
}

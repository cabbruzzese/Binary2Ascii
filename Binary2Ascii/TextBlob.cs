using System.Collections.Generic;

namespace Binary2Ascii
{
    public class TextBlob
    {
        private string delimiterValue;
        private string binaryData;
        private List<char> Ascii7Bytes;
        private List<char> Ascii8Bytes;
        private string ascii7Value;
        private string ascii8Value;

        public string Ascii7Value
        {
            get { return ascii7Value; }
        }

        public string Ascii8Value
        {
            get { return ascii8Value; }
        }

        public TextBlob(string binaryBlob, string delimiter = "")
        {
            binaryData = binaryBlob;
            Ascii7Bytes = Converter.BlobToBytes(binaryData, Converter.ASCII_LENGTH);
            Ascii8Bytes = Converter.BlobToBytes(binaryData, Converter.EASCII_LENGTH);

            delimiterValue = delimiter;

            ascii7Value = Converter.BytesToString(Ascii7Bytes);
            ascii8Value = Converter.BytesToString(Ascii8Bytes);
        }

        public static TextBlob FromString(string str, string delimiter = "")
        {
            List<char> bytes = Converter.StringToBytes(str, Converter.EASCII_LENGTH);
            string blob = Converter.BytesToBlob(bytes, delimiter);

            return new TextBlob(blob, delimiter);
        }

        public string ToBinaryBlob()
        {
            return binaryData;
        }
    }
}

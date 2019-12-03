using System;

namespace MetodosExtensao
{
    public static class Extensao
    {
        public static int WordCount(this string str) =>
            str.Split(new char[] { ' ', '.', '?' },
                StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
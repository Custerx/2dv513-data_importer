using System;

namespace proj2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler f = new FileHandler();
            try
            {
                f.Convert_NDJSON_File_To_JSON();
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

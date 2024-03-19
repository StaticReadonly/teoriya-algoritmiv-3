namespace Classes
{
    public class FileHelper
    {
        public async Task<int[]> ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new ArgumentException("File does not exist");
            }

            using FileStream stream = File.OpenRead(path);
            using StreamReader reader = new StreamReader(stream);

            long size = long.Parse(await reader.ReadLineAsync());

            int[] res = new int[size];

            int i = 0;
            while (!reader.EndOfStream)
            {
                res[i++] = int.Parse(await reader.ReadLineAsync());
            }

            return res;
        }

        public async Task WriteFile(string name, long x, long y, long z)
        {
            using FileStream stream = File.Create(name);
            using StreamWriter writer = new StreamWriter(stream);

            await writer.WriteLineAsync($"{x} {y} {z}");
        }
    }
}

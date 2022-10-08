using System.IO;
void generete(ulong count_gig, string path)
{
    ulong one_gig = 268435456;
    ulong size = 8589934592;
    using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
    {
        int temp;
        Random rnd = new Random();
        //Byte[] b = new Byte[4096];
        for (ulong i = 0; i < 2621440; i++)
        {
            temp = rnd.Next(0, 1000);
            writer.Write(temp);
        }
        Console.WriteLine("Numbers genered!");
    }
}

void divideInTwoFiles(string path, string tempPathB, string tempPathC)
{
    BinaryReader readA = new BinaryReader(new FileStream(path, FileMode.Open));
    BinaryWriter TempB = new BinaryWriter(File.Open(tempPathB, FileMode.OpenOrCreate));
    BinaryWriter TempC = new BinaryWriter(File.Open(tempPathC, FileMode.OpenOrCreate));
    int count = 0;
    int curr, prev = readA.ReadInt32();
    while (readA.BaseStream.Position != readA.BaseStream.Length)
    {
        curr = readA.ReadInt32();
        if (count % 2 == 0)
        {
            if (prev <= curr)
            {
                TempB.Write(prev);
                prev = curr;
            }
            else
            {
                TempB.Write(prev);
                prev = curr;
                count++;
            }
        }
        else
        {
            if (prev <= curr)
            {
                TempC.Write(prev);
                prev = curr;
            }
            else
            {
                TempC.Write(prev);
                prev = curr;
                count++;
            }
        }
    }
    readA.Close();
    TempB.Close();
    TempC.Close();
}

bool isSorted(string path)
{
    BinaryReader readA = new BinaryReader (File.Open(path, FileMode.Open));
    int prev = readA.ReadInt32();
    int curr = readA.ReadInt32();
    while (readA.BaseStream.Position != readA.BaseStream.Length)
    {
        if (prev>curr)
        {
            readA.Close ();
            return false;
        }

        prev = curr;
        curr = readA.ReadInt32();
    }
    readA.Close();
    return true;
}

void merge(string path, string tempB, string tempC)
{
    BinaryReader readerB = new BinaryReader(File.Open(tempB, FileMode.Open));
    BinaryReader readerC = new BinaryReader(File.Open(tempC, FileMode.Open));
    BinaryWriter writeA = new BinaryWriter(File.Open(path, FileMode.Truncate));

    int prevB, prevC;
    int currB = readerB.ReadInt32();
    int currC = readerC.ReadInt32();

    while (true)
    {
        if (readerB.BaseStream.Position == readerB.BaseStream.Length)
        {
            while (readerC.BaseStream.Position != readerC.BaseStream.Length)
            {
                writeA.Write(readerC.ReadInt32());
            }
            break;
        }
        if (readerC.BaseStream.Position == readerC.BaseStream.Length)
        {
            while (readerB.BaseStream.Position != readerB.BaseStream.Length)
            {
                writeA.Write(readerB.ReadInt32());
            }
            break;
        }

        if (currB >= currC)
        {
            writeA.Write(currC);

            prevC = currC;
            currC = readerC.ReadInt32();

            if(prevC > currC && readerB.BaseStream.Position != readerB.BaseStream.Length)
            {
                do
                {
                    writeA.Write(currB);
                    prevB = currB;
                    currB = readerB.ReadInt32();
                } while (prevB <= currB && readerB.BaseStream.Position != readerB.BaseStream.Length);
            }
        }
        else
        {
            writeA.Write(currB);

            prevB = currB;
            currB = readerB.ReadInt32();

            if (prevB > currB && readerC.BaseStream.Position != readerC.BaseStream.Length)
            {
                do
                {
                    writeA.Write(currC);
                    prevC = currC;
                    currC = readerC.ReadInt32();
                } while (prevC <= currC && readerC.BaseStream.Position != readerC.BaseStream.Length);
            }
        }
    }
    readerB.Close();
    readerC.Close();

    //BinaryReader readerBs = new BinaryReader(File.Open(tempB, FileMode.Open));
    //BinaryReader readerCs = new BinaryReader(File.Open(tempC, FileMode.Open));
    //Console.Write("B: ");
    //for (int i = 0; i < 30; i++)
    //{
    //    Console.Write(readerBs.ReadInt32());
    //    Console.Write(", ");
    //}
    //Console.WriteLine();

    //Console.Write("C: ");
    //for (int i = 0; i < 30; i++)
    //{
    //    Console.Write(readerCs.ReadInt32());
    //    Console.Write(", ");
    //}
    //Console.WriteLine();

    //readerBs.Close();
    //readerCs.Close();
    writeA.Close();

    File.Delete(tempC);
    File.Delete(tempB);
}

string path = "UnsortedFilleSmall.txt";
string tempPathB = "TempFileB.txt";
string tempPathC = "TempFileC.txt";

generete(1, path);

while (!isSorted(path))
{
    divideInTwoFiles(path,tempPathB,tempPathC);
    merge(path,tempPathB,tempPathC);
    //BinaryReader readA = new BinaryReader(File.Open(path, FileMode.Open));
    //Console.Write("A: ");
    //for (int i = 0; i < 30; i++)
    //{
    //    Console.Write(readA.ReadInt32());
    //    Console.Write(", ");
    //}
    //Console.WriteLine();
    //readA.Close();
}

Console.WriteLine("File sorted!");



//BinaryReader readAsec = new BinaryReader(new FileStream(path, FileMode.Open));
//BinaryReader TempBR = new BinaryReader(File.Open(tempPathB, FileMode.OpenOrCreate));
//BinaryReader TempCR = new BinaryReader(File.Open(tempPathC, FileMode.OpenOrCreate));

//for (int i = 0; i < 30; i++)
//{
//    Console.Write(readAsec.ReadInt32());
//    Console.Write(", ");
//}
//Console.WriteLine();
//for (int i = 0; i < 10; i++)
//{
//    Console.Write(TempBR.ReadInt32());
//    Console.Write(", ");
//}
//Console.WriteLine();
//for (int i = 0; i < 10; i++)
//{
//    Console.Write(TempCR.ReadInt32());
//    Console.Write(", ");
//}
//Console.WriteLine();
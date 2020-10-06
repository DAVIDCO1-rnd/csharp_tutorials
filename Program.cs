using System;

namespace SortWithDelegate
{
  public delegate int CompareDeleg(int a, int b);
 
  class Program
  {
    static int[] arr;
 
    static int CompareAsc(int x, int y)
    {
      return x - y;
    }
 
    static int CompareDesc(int x, int y)
    {
      return y - x;
    }
 
    static void Sort(CompareDeleg compareMethod)
    {
      for (int i = 0; i < arr.Length - 1; i++)
        for (int j = i + 1; j < arr.Length; j++)
          if (compareMethod(arr[i], arr[j]) > 0)
            Replace(i, j);
    }
 
    private static void Replace(int i, int j)
    {
      int tmp = arr[i];
      arr[i] = arr[j];
      arr[j] = tmp;
    }
 
    static void PrintArr()
    {
      foreach (int num in arr)
        Console.Write(num + ",");
 
      Console.WriteLine();
    }
 
    static void Main(string[] args)
    {
      arr = new int[] { 123, 200, -63, 2, 7612, -13, 8 };
      Console.WriteLine("Orginal nuumbers:");
      PrintArr();
 
      Sort(new CompareDeleg(CompareAsc));
      Console.WriteLine("\nAscending order:");
      PrintArr();
 
      Sort(new CompareDeleg(CompareDesc));
      Console.WriteLine("\nDescending order:");
      PrintArr();
    }
  }
}
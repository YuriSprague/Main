using System;
using System.Collections.Generic;
using System.Linq;

//For simplicity in this test, just work with an int array.
//Also, use Lists and LINQ.
//No error testing or exception checking.

public class Test
{
   public static void Main()
   {
      int[] test = { 1, 2, 3, 4, 5, 6 };
      Robot robot = new Robot();
      SortChip sort = new SortChip(test);
      SumChip sum = new SumChip(test);

      robot.AddChip(sort);

      int[] result = robot.ExecuteChip();

       Console.WriteLine("Array in sorted order:");

      foreach (var value in result)
         Console.WriteLine(value.ToString());

      robot.AddChip(sum);
      result = robot.ExecuteChip();

      Console.WriteLine("Array sum:");
       Console.WriteLine(result[0].ToString());
   }
}

public class Robot
{
   public uint ChipCount { get; private set; }
   private SortChip _sortChip = null;
   private SumChip _sumChip = null;

   public Robot()
   {
      this.ChipCount = 0;
   }

   public void AddChip(object chip)
   {
      this.ChipCount++;

      if (chip is SortChip)
      {
         this._sortChip = (SortChip) chip;
         this._sumChip = null;
      }

      else
      {
         this._sortChip = null;
         this._sumChip = (SumChip) chip;
      }
   }

   public int[] ExecuteChip()
   {
      if (this._sumChip == null)
      {
          return this._sortChip.Sort();
      }

      else
      {
          return this._sumChip.Sum();
      }
   }
}

public class SortChip
{
   List<int> _list = new List<int>();

   public SortChip(int[] toSort)
   {
      this._list = toSort.ToList();
   }
 
   public int[] Sort(bool sortAscending = true)
   { 
       if (sortAscending)
         return this._listOrderBy(o => o).ToArray();

      else
         return this._list.OrderByDescending(o => o).ToArray();
   }
}

public class SumChip
{
   private List<int> _list = new List<int>();

   public SumChip(int[] toSum)
   {
      this._list = toSum.ToList();
   }

   public int[] Sum()
   {
      int sum = 0;

      foreach (int element in this._list)
        sum += element;

      return sum.ToArray();
   }
}

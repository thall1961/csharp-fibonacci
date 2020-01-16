using System;
using System.IO;
using System.Collections.Generic;

namespace fib
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("\n********************************************\nWelcome! Enter a number or 'x' to quit.\n********************************************");
      do
      {
        var nums = new List<int> { 0, 1 };
        Console.WriteLine("\nHow many fibonacci numbers do you want to print?");
        var response = Console.ReadLine();
        var flag = ProcessResponse(nums, response, int.TryParse(response, out int n));
        if (!flag)
          break;
      } while (true);
    }

    static bool ProcessResponse(List<int> nums, string response, bool isInt)
    {
      if ((response != "x") && isInt)
      {
        // response is an integer and not the escape character
        var fibNumbers = Int32.Parse(response);
        Console.WriteLine($"1: {nums[0]}\n2: {nums[1]}");
        fib(nums, fibNumbers);
        return true;
      }
      else if (!isInt && response != "x")
      {
        // response is not a number and not the escape character
        Console.WriteLine("********************************************\nPlease enter a digit.\n********************************************");
        return true;
      }
      else
      {
        // response is the escape character, exit program
        Console.WriteLine("********************************************\nGoodbye!\n********************************************");
        return false;
      }
    }

    static void fib(List<int> nums, int length)
    {
      if (nums.Count < length)
      {
        nums.Add(nums[nums.Count - 1] + nums[nums.Count - 2]);
        if (nums.Count > 47)
        {
          Console.WriteLine($"{nums.Count}: HUGE NUMBER!!!");
        }
        else
        {
          Console.WriteLine($"{nums.Count}: {nums[nums.Count - 1]}");
        }
        fib(nums, length);
      }
    }
  }
}


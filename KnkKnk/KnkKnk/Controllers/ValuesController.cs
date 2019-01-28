using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KnkKnk.Model;
using Microsoft.AspNetCore.Mvc;

namespace KnkKnk.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("Values")]
        public string Values()
        {
            return "Knock Knock";
        }
        [Route("ReverseWords")]
        public ActionResult<string> ReverseWords([FromQuery] string sentence)
        {
            Debug.WriteLine($"Requested sentence is {sentence}");
            string reverseString = string.Empty;
            try

            {
                if (string.IsNullOrEmpty(sentence))
                    return string.Empty;
                reverseString = new string(sentence.Reverse().ToArray());
            }
            catch (Exception ex)
            {
                this.NotFound();
            }
            return this.Ok(reverseString);
        }
        [Route("Fibonacci")]
        public ActionResult<long> Fibonacci([FromQuery] int n)
        {
            Debug.WriteLine($"Requested number is {n}");
            if (n > 92)
                return this.NotFound();
            Dictionary<int, long> fibDictionary = new Dictionary<int, long>();
            try
            {
                fibDictionary.Add(0, 0);
                fibDictionary.Add(1, 1);
                FibCalc(n, ref fibDictionary);
                long fib = fibDictionary.FirstOrDefault(e => e.Key.Equals(n)).Value;
                return this.Ok(fib);
            }
            catch (Exception ex)
            {
                this.NotFound();
            }
            return this.Ok();
        }
        public static long FibCalc(int n, ref Dictionary<int, long> fibDictionary)
        {
            if (fibDictionary.Keys.Contains(n))
                return fibDictionary[n];

            long ans = FibCalc(n - 2, ref fibDictionary) + FibCalc(n - 1, ref fibDictionary);
            fibDictionary.Add(n, ans);
            return ans;


        }
        [Route("TriangleType")]
        public ActionResult<string> TriangleType([FromQuery] int a, [FromQuery] int b, [FromQuery] int c)
        {
            Debug.WriteLine($"Requested triangle type is {a}, {b} and {c}");
            Triangle triangle = new Triangle(a, b, c);
            return triangle.TriangleType.ToString();

        }

        [Route("Token")]
        public ActionResult<string> Token()
        {
            return "0073d45c-6b33-4b47-bd1e-6868a6086f15";
        }
    }
}

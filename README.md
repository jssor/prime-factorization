
Prime Factorization (2d space hit algorithm)

#### Code
```html
<pre>
    /// <summary>
    /// Prime Factorization (2d space hit algorithm)
    /// </summary>
    private static List<long> Factorize(long number)
    {
        List<long> list = new List<long>();

        double sqrt = Math.Sqrt(number);
        long x = (long)sqrt;
        long y = x;

        if(y > 1)
        {
            long remainder = number - x * y;

            while (remainder != 0)
            {
                y--;

                remainder += x;
                long mode = remainder % y;
                x += remainder / y;
                remainder = mode;
            }
        }

        if (y == 1)
        {
            list.Add(number);
        }
        else
        {
            list.AddRange(Factorize(x));
            list.AddRange(Factorize(y));
        }

        return list;
    }
</pre>
```

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
        long remainder = number - x * y;

        while (remainder != 0)
        {
            if (remainder > 0)
            {
                long x1 = remainder / y;
                if (remainder % y > 0)
                {
                    x1++;
                }
                remainder -= x1 * y;
                x += x1;
            }
            else
            {
                long y1 = -remainder / x;
                if (-remainder % x > 0)
                {
                    y1++;
                }
                y -= y1;
                remainder += x * y1;
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
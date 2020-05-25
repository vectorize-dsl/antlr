# ANTLR-based implementation of Vectorize

This repository contains the ANTLR-based implementation of Vectorize. In its core it is an interpreter.

## Example: Fibonacci

```
fn main() {
    setup(5000, 1000);
    text(10, 35, "Fibonacci");

    setFill("black");
    setFontSize(12);
    
    let fibs: int[] = fibonacci_iter(30);
    for(let i: int = 0; i < length(fibs); i++) {
        let value: int = fibs[i];
        
        setFill("black");
        text(10, i * 10 + 60, toString(i));
        text(30, i * 10 + 60, toString(value));

        if (i % 2 == 0)
           setFill("darkblue");
        else
           setFill("darkgreen");
        rect(80, i * 10 + 50, value, 10);
    }
}

fn fibonacci_rec(n: int) -> int {
    if (n == 1 || n == 2)
        return 1;
    return fibonacci_rec(n - 2) + fibonacci_rec(n - 1);
}

fn fibonacci_iter(n: int) -> int[] {
    let series: int[n];
    for (let i: int = 0; i < n; i++) {
        if (i == 0 || i == 1)
          series[i] = 1;
        else
          series[i] = series[i - 1] + series[i - 2];
    }
    return series;
}
```

Output:
![Output of the above Vectorize program](doc/fibonacci.png)

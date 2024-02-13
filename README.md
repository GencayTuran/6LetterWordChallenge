# 6 letter words
There's a file in the root of the repository, input.txt, that contains words of varying lengths (1 to 6 characters).

Your objective is to show all combinations of those words that together form a word of 6 characters. That combination must also be present in input.txt
E.g.:  
<code>
foobar  
fo  
obar  
</code>

should result in the ouput:  
<code>
fo+obar=foobar
</code>

You can start by only supporting combinations of two words and improve the algorithm at the end of the exercise to support any combinations.

Treat this exercise as if you were writing production code; think unit tests, SOLID, clean code and avoid primitive obsession. Be mindful of changing requirements like a different maximum combination length, or a different source of the input data.

The solution must be stored in a git repo. After the repo is cloned, the application should be able to run with one command / script.

Don't spend too much time on this.

## Features and Tasks

1. **Input Data Processor**
   - Get input data and put data into a collection.

2. **Data Combinator Service**
   - Iterate data over combination logic.
     - Combine every 2 words that make up a word of 6 chars in total from the input data.
     - (Later make this logic able to handle different combinations or different source of input data as well.)

3. **Combination Presentator Service**
   - Present end result for each combination.
     - Example: `fo + obar = foobar`

4. **Refactoring and Principles Implementation**
   - Refactor and implement the SOLID principles.
     - Make every service readable and testable.

5. **Unit Testing**
   - Create unit tests for every service.

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

## features and tasks

1. input data processor
  - get input data
  - put data into collection

2. data combinator service
  - iterate data over combination logic
  - logic: combine every 2 words that make up a word of 6 chars in total from the input data
  - (later make this logic able to handle different combinations as well.)

3. combination presentator service
  - present end result for each combiantion as following example: fo+obar=foobar

4. refactoring and principles implementation
  - refactor and implement the SOLID principles
  - make every service readable and testable

5. unit testing
  - create unit tests for every service

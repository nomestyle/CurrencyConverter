# CurrencyConverter
Convert a two decimal point float to a word representation of the currency value

## To Run
A pre-packaged .exe can be found in the ..\CurrencyConverter\CurrencyConverter\bin\Release\net6.0 folder.
double click on the .exe to run (this may be limited to windows machines only)

## To Test
Open the solution ..\CurrencyConverter\CurrencyConverter\CurrencyConverter.sln in Visual Studio and the tests can be run from the test explorer

## Limitations
The highest number you can possibly get is 
Nine Hundred and Ninety Nine Billion Nine Hundred and Ninety Nine Million Nine Hundred and Ninety Nine Thousand Nine Hundred and Ninety Nine Dollars and Ninety Nine Cents 
which means that the largest number is 999999999999.99
There is no handling for negative numbers so it will return ignoring the negative.
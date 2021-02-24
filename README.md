# Pesel validation

## What is PESEL

The PESEL number is an eleven-digit polish national identification number. The PESEL number includes the date of birth, serial number, gender and the check digit. 

## What do the digits in the PESEL number mean

Each of the 11 digits in the PESEL number has its own meaning. They can be classified as follows, YYMMDDNNNNC:
 1. RR the last 2 digits of the year of birth.
 2. MM is the month of birth (in order to distinguish PESEL numbers from different centuries, a special method of coding the month of birth was adopted).
 3. DD is the day of birth.
 4. NNNN is an ordinal number also representing gender. For women, the last digit of this number is even (0, 2, 4, 6, 8), and for men - odd (1, 3, 5, 7, 9).
 5. C is a redundancy check digit used for error detection.

## How to calculate the check digit

To calculate the check digit in PESEL number the following three steps need to be peformed:
 1. Multiply each digit of the PESEL number by the appropriate weight: 1-3-7-9-1-3-7-9-1-3.
  + Y * 1 = I1
  + Y * 3 = I2
  + M * 7 = I3
  + M * 9 = I4
  + D * 1 = I5
  + D * 3 = I6
  + N * 7 = I7
  + N * 9 = I8
  + N * 1 = I9
  + N * 3 = I10
 2. Sum the obtained multiplication results together: I1 + I2 + I3 + I4 + I5 + I6 + I7 + I8 + I9 + I10 = RESULT. If the result of the multiplication is a two-digit number, only add the last digit (for example, add 3 instead of 13). 
 3. Subtract the RESULT from 10. Note: if adding RESULT is a two-digit number, only the last digit should be subtracted (for example, instead of 31, subtract 1). The received digit is the final contol digit.


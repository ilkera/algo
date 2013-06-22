"""
Problem: Two Sum
Given an array of integers, find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target,
where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

You may assume that each input would have exactly one solution.

Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2

"""
# Two sum method that returns indices of two items that sum up to target
def twoSum(numbers, target):
    if not numbers:
        raise Exception('Empty/null array')

    indices = () # define a tuple
    numbersSeenSoFar = {}
    for index in range(len(numbers)):
        if (target - numbers[index]) not in numbersSeenSoFar:
            numbersSeenSoFar[numbers[index]] = index
        else:
            indices = numbersSeenSoFar[target - numbers[index]], index
            break
    return indices

# Test
numbers = [2, 7, 11, 15]
target = 18
indices = twoSum(numbers, target)
print("Indices: %d and %d" % (indices[0], indices[1]))

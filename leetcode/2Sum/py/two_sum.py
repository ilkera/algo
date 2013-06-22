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

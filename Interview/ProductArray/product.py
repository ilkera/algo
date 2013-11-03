# Given an array of numbers, nums, return an array of numbers products,
# where products[i] is the product of all nums[j], j != i
#Input : [1, 2, 3, 4, 5]
#Output: [(2*3*4*5), (1*3*4*5), (1*2*4*5), (1*2*3*5), (1*2*3*4)]
#     = [120, 60, 40, 30, 24]
#You must do this in O(N) without using division.

def product(numbers):
    if not numbers:
        raise Exception('Empty/null input array')

    out = []
    result = 1
    for index in range(len(numbers)):
        out.append(result)
        result *= numbers[index]

    result = 1
    for index in range(len(numbers) - 1, -1, -1):
        out[index] *= result;
        result *= numbers[index]

    print("Out: %s " % out)

# Test #
numbers = [2, 3, 4]
product(numbers)
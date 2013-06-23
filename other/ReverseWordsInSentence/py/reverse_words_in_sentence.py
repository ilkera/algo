# Reverse words in a string using built-in string functions
str = "This is a sentence"
print(str)
reversed = " ".join(str.split(" ")[::-1])
print(reversed)

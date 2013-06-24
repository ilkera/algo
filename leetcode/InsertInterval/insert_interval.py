"""
Problem: Insert Interval

Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

You may assume that the intervals were initially sorted according to their start times.

Example 1:
Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].

Example 2:
Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].

This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].

"""
import sys

def insertInterval(intervals, newInterval):
    merged = []

    merged_finished = False
    start, end = newInterval[0], newInterval[1]
    for interval in intervals:
        if interval[1] >= start  and end >= interval[0]:
            start = start if start < interval[0] else interval[0]
            end = end if end > interval[1] else interval[1]
            continue
        if merged_finished == False and interval[0] > end:
            merged.append((start, end))
            merged_finished = True
        merged.append((interval[0], interval[1]))

    if merged_finished == False:
        merged.append((start, end))
    return merged


intervals = [(1,2),(3,5),(6,7),(8,10),(12,16)]
newInterval = (4, 9)

print("Insert before Intervals: %s" % intervals)
merged = insertInterval(intervals, newInterval)
print("Insert after Intervals: %s" % merged)

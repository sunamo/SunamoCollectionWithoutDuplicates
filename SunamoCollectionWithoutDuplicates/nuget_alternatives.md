# NuGet Alternatives to SunamoCollectionWithoutDuplicates

This document lists popular NuGet packages that provide similar functionality to SunamoCollectionWithoutDuplicates.

## Overview

Collections that prevent duplicate entries

## Alternative Packages

### System.Collections.Generic.HashSet
- **NuGet**: System.Collections
- **Purpose**: Built-in set implementation
- **Key Features**: O(1) lookups, automatic deduplication

### System.Collections.Concurrent.ConcurrentBag
- **NuGet**: System.Collections.Concurrent
- **Purpose**: Thread-safe collection
- **Key Features**: Concurrent access, unordered collection

### MoreLINQ
- **NuGet**: morelinq
- **Purpose**: LINQ extensions including DistinctBy
- **Key Features**: Advanced LINQ operations, custom equality comparers

## Comparison Notes

HashSet<T> is the standard .NET approach for duplicate-free collections.

## Choosing an Alternative

Consider these alternatives based on your specific needs:
- **System.Collections.Generic.HashSet**: Built-in set implementation
- **System.Collections.Concurrent.ConcurrentBag**: Thread-safe collection
- **MoreLINQ**: LINQ extensions including DistinctBy

# Linq-FilterLists
This sample illustrates the use of Linq to filter two lists of complex objects between them.
Mainly, I developed it as a reminder for myself. I'll write a quick blog post in the upcoming days so visitors get a better understanding of what it's all about... And there's a chance I add some stuff.

Anyway, I'll add the post link here when it'll be ready.

## What you'll see
* Common items :
```
_localDatabase.Where(f => _updatedList.Any(s => s.Index == f.Index))
```
* New items :
```
_updatedList.Where(s => _localDatabase.All(f => f.Index != s.Index))
```
* Deleted items :
```
_localDatabase.Where(f => _updatedList.All(s => s.Index != f.Index))
```

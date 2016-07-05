# WaniKani Private C# API
A C# library to interface with the private &amp; undocumented API of the kanji learning service, WaniKani.
This library was written to provide developers a means to build their own WaniKani client applications in C#, and as such, make WaniKani
a more rich and exciting place to learn Japanese!

**This library is super young right now, and it's terribly thin and flimsy.**

### Examples
##### Get the user's review queue & update an item's progress
```csharp
// Log in
var wanikani = new WaniKaniClient();
var user = wanikani.Login(username, password);

// Gather the user's review queue
var reviewClient = new WaniKaniReviewClient(user);
var reviews = reviewClient.GetReviews();

// Update the SRS progress for the first item in the queue.
// Parameters indicate the number of failed attempts.
reviewClient.UpdateItemProgress(
    card: item, 
    meaningFailures: 0, 
    readingFailures: 0);
```
##### Get the details of a kanji
```csharp
var wanikani = new WaniKaniClient();
var user = wanikani.Login("user@example.com", "password");

var kanjiClient = new WaniKaniKanjiClient(user);
var kanji = kanjiClient.GetKanji(42);
```

### Existing Features
* WaniKani user authentication
* Retrieve a user's review queue and lesson queue
* Gather information about any radical, kanji or vocabulary item
* Report on the progress of a review item

### To Do
* Design a more abstracted queryable data structure for retrieving items with LINQ
* Fix bugs and timing issues
* Implement async functions

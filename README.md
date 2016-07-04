# WaniKani Private C# API
A C# library to interface with the private &amp; undocumented API of the kanji learning service, WaniKani.
This library was written to provide developers a means to build their own WaniKani client applications in C#, and as such, make WaniKani
a more rich and exciting place to learn Japanese!

**This library is super young right now, and it's terribly thin and flimsy.**

### Examples
##### Gather a collection of reviews
```csharp
WaniKaniClient wanikani = new WaniKaniClient();
WaniKaniUser user = wanikani.Login("user@example.com", "password");
WaniKaniReviewQueue reviews = wanikani.GetReviewsFor(user);
```
##### Get the details of a kanji
```csharp
WaniKaniClient wanikani = new WaniKaniClient();
WaniKaniUser user = wanikani.Login("user@example.com", "password");

WaniKaniKanjiClient kanjiClient = new WaniKaniKanjiClient(user);
WaniKaniKanji kanji = kanjiClient.GetKanji(42);
```

### Existing Features
* WaniKani user authentication
* Retrieve a user's review queue
* Gather information about any kanji or vocabulary item

### Anticipated Features
* Design a more abstracted queryable data structure for retrieving items with LINQ.
* Interface with the endpoint for review item updates (ie, allow reviews to be completed).
* Build a lesson client.

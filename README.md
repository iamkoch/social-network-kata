# Social Network Kata

## Trade-offs and Decisions
1. Chose static over instance for users as I felt it made the in-memory store more explicit
2. Didn't implement a repository or associated pattern as felt overkill for happy-path, in-memory (see 1)
3. A mix of static SystemTime access and passing it in. Would likely tidy this up and settle on one approach.
4. History will show me working towards a passing test and then refactoring. I would typically rebase my unpushed commits into a more cohesive reflection of the state of the feature, and only push when code is releasable.


## Thoughts
1. I'm unsure of the exposure of User.DisplayName within the Posts entity.
2. Command.Execute takes no params meaning input is a constructor param. This would most likely change in a more CQS-style pattern, but served a simple place to see the steps required by a given path
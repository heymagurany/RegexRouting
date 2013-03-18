Regular Expression Routing
==========================
--------------------------
If you run into any trouble or have any suggestions, please log them in the [Issue Tracker] (https://github.com/honkywater/RegexRouting/issues). Enjoy!

### Changelog

#### v1.0.3

* Created the RegexRoute class, which enables developers to include a regular expression for URL matching.

#### v1.1.0

* URLs and patterns use the same pattern (no ~/)
 * Set RegexRoute.UseLegacy = true to use the v1.0 pattern.
* Added support for Areas
* Added support for automatic constraint generation

#### v2.0.0

* Added a separate package for meant to me used along side ASP.NET MVC which simplifies route creation via extension methods.
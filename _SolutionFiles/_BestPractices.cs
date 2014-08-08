
namespace NONE // Here only for documentation, not part of the solution
{
    /// <summary>
    /// _BestPractices (part of C# Coding Standards)
    /// </summary>
    /// <remarks>
    /// To provide coding methods inside the code where it is readily available to developers, this class
    /// can be added to a _SolutionFiles folder in a .sln for easy reference.
    /// </remarks>
    class _BestPractices
    {
        /// <summary>
        ///  Which array type to use when more than one dimension
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li>Reason    : Use jagged arrays due to Microsoft's compiler</li>
        /// <li>Rationale : Jagged arrays (array of arrays / vector of vectors) are more efficient than multi-dimensional (rectangular) arrays
        ///   <ul>
        ///     <li>Jagged arrays can easily perform such operations as row swap and row resize</li>
        ///     <li>http://stackoverflow.com/questions/597720/what-is-differences-between-multidimensional-array-and-array-of-arrays-in-c</li>
        ///     <li>http://community.bartdesmet.net/blogs/bart/archive/2007/03/13/answers-to-c-quiz-need-for-speed.aspx</li>li>
        ///     <li>http://stackoverflow.com/questions/468832/why-are-multi-dimensional-arrays-in-net-slower-than-normal-arrays</li>
        ///   </ul>
        /// </li>
        /// <li>Notes     : You might want to consider using a<![CDATA[ List<T> or Dictionary<T> ]]></li>
        /// <li>References: http://www.c-sharpcorner.com/UploadFile/mahesh/WorkingWithArrays11232005064036AM/WorkingWithArrays.aspx</li>
        /// <li>Keywords  : array, matrix, dimension</li>
        /// </ul>
        /// 
        /// DON'T:  int[,] numbers = new int[,] { {1, 2}, {3, 4}, {5, 6} };
        ///
        /// DO:     int[][] numbers = { new int[] {1,2,3,4}, new int[] {5,6,7,8,9} };
        /// </remarks>
        private void Array__Which_array_type_to_use_when_more_than_one_dimension()
        {
        }

        /// <summary>
        /// Boolean test for equality (bool, NOT bool?)
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li>Reason    : Code reduction</li>
        /// <li>Rationale : Booleans are either true or false, so equating them is redundant</li>
        /// <li>Not for   : Nullable booleans (bool?), so == is needed for the implicit cast from bool? to bool</li>
        /// <li>Keywords  : boolean true false not equal equals</li>
        /// </ul>
        /// DON'T:  if (myBoolean == true)
        /// DO:     if (myBoolean)
        /// 
        /// DON'T:  if (myBoolean == false)
        /// DO:     if (!myBoolean)
        /// 
        /// DON'T:  if (myBoolean != true)
        /// DO:     if (!myBoolean)
        /// </remarks>
        private void Boolean__Test_for_Equality()
        {
        }

        /// <summary>
        ///  iif
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li>Reason    : Type-safe, non-short-circuiting ternary</li>
        /// <li>Rationale : An iif(true, 1, 1/0) function call would result in a division by zero error and is not type-safe</li>
        /// <li>Keywords  : iif ? ??</li>
        /// </ul>
        /// DON'T:  create an iif function
        ///
        /// DO:     int doesNotCauseDivideByZeroException = (true) ? 1 : 1/0;
        /// DO:     string s = someBool ? "someBool is true" : "someBool is false";
        /// </remarks>
        private void General_iif()
        {
        }

        /// <summary>
        /// Add standardized comment for rewriting code from the old X application to X.NET
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li>Reason    : Location / Coverage</li>
        /// <li>Rationale : Standardization means we can always map the old X application's routine to the new X.NET method</li>
        /// <li>Keywords  : X app application standard rewrite migrate</li>
        /// </ul>
        /// DON'T:  use free-style comments
        ///
        /// DO:     // App_to_App.NET_Rewrite: X.Y (where Y is a routine in the old app's X class)
        /// </remarks>
        private void General_Rewrite_of_Old_App()
        {
        }

        /// <summary>
        /// Check for any records in LINQ
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li>Reason    : Performance</li>
        /// <li>Rationale : Any() stops as soon as it detects a record, whereas Count() needs to count them all</li>
        /// <li>Keywords  : LINQ records any count zero 0 exist exists</li>
        /// </ul>
        /// DON'T:  ... .Count() > 0
        ///
        /// DO:     ... .Any()
        /// </remarks>
        private void LINQ__Check_for_any_records()
        {
        }

        /// <summary>
        /// Concatenating folder or file paths
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li>Reason    : Readability, maintenance, code reduction</li>
        /// <li>Rationale : MS provides an easy way to combine paths, so we do not have check for a trailing backslash</li>
        /// <li>Keywords  : file folder path concatenate catenate backslash slash</li>
        /// </ul>
        /// DON'T:  check for a trailing backslash and add one if not there
        ///
        /// DO:     string filePath = string.Format("{0}.{1}", Path.Combine(folderPath, fileName), fileExtension);
        /// </remarks>
        private void Path_Concatenate()
        {
        }

        /// <summary>
        ///  Check for null or empty string
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li>Reason    : Performance</li>
        /// <li>Rationale : http://www.dotnetperls.com/isnullorempty shows the null and length checks are the fastest, but we are first opting for readability</li>
        /// <li>Keywords  : string null zero 0 length empty</li>
        /// </ul>
        /// WHEN READABILITY MATTERS (TYPICAL), DON'T:  if (s == null || s.Length == 0) ...
        ///
        /// WHEN READABILITY MATTERS (TYPICAL), DO:     if (string.IsNullOrEmpty(s)) ...
        ///
        ///
        /// WHEN PERFORMANCE MATTERS, DON'T:  if (string.IsNullOrEmpty(s)) ...
        ///
        /// WHEN PERFORMANCE MATTERS, DO:     if (s == null || s.Length == 0) ... 
        /// </remarks>
        private void String__Check_for_null_or_empty_string()
        {
        }

        /// <summary>
        /// Check for null or empty string or one that contains only whitespace
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li>Reason    : Performance</li>
        /// <li>Rationale : http://www.dotnetperls.com/isnullorempty shows the null and length checks are the fastest, but we are first opting for readability</li>
        /// <li>Keywords  : string null zero 0 length empty white space whitespace IsNullOrEmptyOrWhiteSpace</li>
        /// <li>Note      : Whitespace is a space, \n (new line), \r (carriage return), \t (tab), \v (vertical space)</li>
        /// </ul>
        /// DON'T:  if (s == null || s.Length == 0)
        ///
        /// DO:     if (string.IsNullOrWhiteSpace(s)) ...
        /// </remarks>
        private void String__Check_for_null_or_empty_or_only_whitespace_string()
        {
        }

        /// <summary>
        /// Test a string for equality
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li>Reason    : Standardization</li>
        /// <li>Rationale : Standardizing our equality tests means we can always test strings the same way</li>
        /// <li>Keywords  : string equal equals == !=</li>
        /// </ul>
        /// DON'T:  if (myString == "Some value")
        /// DON'T:  if (!string.IsNullOrEmpty(myString) && myString.ToLower() == "some value")
        /// 
        /// DO:  if (!string.IsNullOrEmpty(myString) && myString.Equals("some value", StringComparison.OrdinalIgnoreCase))) // case insensitive
        /// DO:  if (!string.IsNullOrEmpty(myString) && myString.Equals("Some value")) // case sensitive
        ///
        /// (OBSOLETE) DO:     if (myString.IsEquivalentTo("Some value", true))  // when the value could be localized
        /// (OBSOLETE) DO:     if (myString.IsEquivalentTo("Some value", false)) // when the value is not localized (American English)
        /// </remarks>
        private void String__Test_for_Equality()
        {
        }
    }
}

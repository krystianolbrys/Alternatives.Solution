using AlternativesSolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlternativesSolution.Processors
{
    public class AlternativesProcessor
    {
        public IReadOnlyList<Alternative> Process(CustomerPreferences customerPreferences, IReadOnlyList<MatrixCase> matrix)
        {
            Validate(customerPreferences, matrix);

            // walidacja karencji dla reguły po Id reguły i userId zapisanego w DB/JSON czy czym tam, modyfikacja jakiegoś w modelu "data" pola "czatów"

            var validRules = ValidRules(customerPreferences, matrix);

            if (validRules.Count() != 1)
            {
                throw new Exception();
            }

            return validRules.Single().Alternatives;
        }

        private IEnumerable<MatrixCase> ValidRules(CustomerPreferences customerPreferences, IReadOnlyList<MatrixCase> matrix) =>
            matrix.Where(rule =>
                rule.IsYourLaptopFast == customerPreferences.IsYourLaptopFast
                && rule.IsYourCarTurboCharged == customerPreferences.IsYourCarTurboCharged);

        private void Validate(CustomerPreferences customerPreferences, IReadOnlyList<MatrixCase> matrix)
        {
            if (matrix == null || matrix.Count == 0)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (customerPreferences == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }
        }
    }
}

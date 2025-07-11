using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoMunicipio.Model;

namespace ProjetoMunicipio.Specifications
{
    public class PopulacaoRangeSpecification : IPopulacaoSpecification
    {
        private readonly int? _min;
        private readonly int? _max;

        public PopulacaoRangeSpecification(int? min, int? max)
        {
            _min = min;
            _max = max;
        }

        public bool IsSatisfiedBy(Municipio m)
        {
            return (!_min.HasValue || m.Populacao >= _min.Value)
                && (!_max.HasValue || m.Populacao <= _max.Value);
        }
    }
}

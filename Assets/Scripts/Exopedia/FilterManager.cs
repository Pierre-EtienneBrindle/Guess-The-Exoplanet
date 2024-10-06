using System.Collections;
using System.Collections.Generic;

class FilterManager
{
    public List<Filter> Filters { get; private set; }

    public FilterManager()
    {
        Filters = new List<Filter>();
    }

    public void RemoveFilter(int index)
    {
        Filters.RemoveAt(index);
    }

    public void ClearFilters()
    {
        Filters.Clear();
    }

    public List<ExoplanetData> GetFilteredPlanets()
    {
        BitArray bitArray = new(ExoplanetDataStorer.Instance.Planets.Count);
        bitArray.SetAll(true);

        for (int i = 0; i < Filters.Count; i++)
        {
            bitArray = bitArray.And(Filters[i].GetFilterBitArray());
        }

        List<ExoplanetData> outList = new();
        for (int i = 0; i < ExoplanetDataStorer.Instance.Planets.Count; i++)
        {
            if (bitArray[i] == true)
            {
                outList.Add(ExoplanetDataStorer.Instance.Planets[i]);
            }
        }
        return outList;
    }
}

using System.Collections;
using System.Collections.Generic;

class FilterManager
{
    public List<Filter> Filters { get; private set; }

    FilterManager()
    {
        Filters = new List<Filter>();   
    }

    public void RemoveFilter(int index)
    {
        Filters.RemoveAt(index);
    }

    public List<ExoplanetData> GetFilteredPlanets(List<ExoplanetData> data)
    {
        BitArray bitArray = new(data.Count);
        bitArray.SetAll(true);

        for (int i = 0; i < Filters.Count; i++)
        {
            bitArray = bitArray.Xor(Filters[i].GetFilterBitArray(data));
        }

        List<ExoplanetData> outList = new();
        for (int i = 0; i < data.Count; i++)
        {
            if (bitArray[i])
            {
                outList.Add(data[i]);
            }
        }
        return outList;
    }
}

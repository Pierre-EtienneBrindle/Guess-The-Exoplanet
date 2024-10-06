using System;
using System.Collections;
using System.Collections.Generic;

public enum FilterType
{
    NbStars,
    NbPlanet,
    RadiusInEarth,
    Temperature,
    MassInEarth,
    OrbitDurationInDays,
    DistanceFromEarth,
    TransitDuration,
}

public enum FilterOrdering
{
    Lesser,
    Equal,
    Greater,
}

class Filter
{
    private FilterType type;
    public FilterType Type { 
        get { 
            return type; 
        }
        set {
            outputComputed = false;
            type = value;
        } 
    }

    private FilterOrdering ordering;
    public FilterOrdering FilterOrdering { 
        get { 
            return ordering; 
        }
        set {
            outputComputed = false;
            ordering = value;
        } 
    }

    private float limit;
    public float Limit { 
        get { 
            return limit; 
        }
        set {
            outputComputed = false;
            limit = value;
        } 
    }

    private BitArray output;
    private bool outputComputed;

    public Filter(FilterType filterType, FilterOrdering ordering, float limit)
    {
        this.type = filterType;
        this.ordering = ordering;
        this.limit = limit;
        output = new(0);
        outputComputed = false;
    }

    public BitArray GetFilterBitArray()
    {
        if (outputComputed)
        {
            return output;
        }

        Func<ExoplanetData, float?> propertyGetterLambda;
        switch (type)
        {
            case FilterType.NbStars:
                propertyGetterLambda = (x) => x.NbStars;
                break;
            case FilterType.NbPlanet:
                propertyGetterLambda = (x) => x.NbPlanet;
                break;
            case FilterType.RadiusInEarth:
                propertyGetterLambda = (x) => x.RadiusInEarth;
                break;
            case FilterType.Temperature:
                propertyGetterLambda = (x) => x.Temperature;
                break;
            case FilterType.MassInEarth:
                propertyGetterLambda = (x) => x.MassInEarth;
                break;
            case FilterType.OrbitDurationInDays:
                propertyGetterLambda = (x) => x.OrbitDurationInDays;
                break;
            case FilterType.DistanceFromEarth:
                propertyGetterLambda = (x) => x.DistanceFromEarth;
                break;
            case FilterType.TransitDuration:
                propertyGetterLambda = (x) => x.TransitDuration;
                break;
            default:
                propertyGetterLambda = null;
                break;
        }

        Func<float, float, bool> orderingLambda;
        switch (ordering)
        {
            case FilterOrdering.Lesser:
                orderingLambda = (a, b) => a < b;
                break;
            case FilterOrdering.Equal:
                orderingLambda = (a, b) => System.Math.Abs(a - b) < 0.01;
                break;
            case FilterOrdering.Greater:
                orderingLambda = (a, b) => a > b;
                break;
            default:
                orderingLambda = null;
                break;
        }

        output = new(ExoplanetDataStorer.Instance.Planets.Count);
        output.SetAll(true);
        for (int i = 0; i < ExoplanetDataStorer.Instance.Planets.Count; i++)
        {
            if (propertyGetterLambda(ExoplanetDataStorer.Instance.Planets[i]) == null)
            {
                output[i] = false;
            }
            else
            {
                output[i] = orderingLambda(propertyGetterLambda(ExoplanetDataStorer.Instance.Planets[i]).Value, limit);
            }
        }
        outputComputed = true;
        return output;
    }
}

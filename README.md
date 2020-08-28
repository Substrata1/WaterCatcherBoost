**Water Catcher Boost** allows you to boost the collection rate of water catchers and water pumps.

This plugin does not alter the default rates.

## Configuration
The minimum and maximum boost per minute can be set in the configuration.
* The maximum boost must be greater than (or equal to) the minimum.
* All values must be whole numbers (no decimals).

```json
{
  "Large Water Catchers": {
    "Minimum Boost (per minute)": 0,
    "Maximum Boost (per minute)": 60
  },
  "Small Water Catchers": {
    "Minimum Boost (per minute)": 0,
    "Maximum Boost (per minute)": 20
  },
  "Water Pumps": {
    "Minimum Boost (per minute)": 0,
    "Maximum Boost (per minute)": 510
  }
}
```


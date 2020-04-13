<b>Water Catcher Boost</b> allows you to boost the collection rates of water catchers.

This plugin does not alter the default rates.

## Configuration
The minimum and maximum boost per minute can be set for both water catcher types in the configuration.
* The maximum boost must be greater than (or equal to) the minimum.
* All values must be whole numbers (no decimals).

```json
{
  "Large Water Catchers": {
    "Maximum Boost (per minute)": 60,
    "Minimum Boost (per minute)": 0
  },
  "Small Water Catchers": {
    "Maximum Boost (per minute)": 20,
    "Minimum Boost (per minute)": 0
  }
}
```


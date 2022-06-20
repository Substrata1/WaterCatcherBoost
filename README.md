**Water Catcher Boost** allows you to boost the collection rate of water catchers and water pumps.

This plugin does not alter the default rates, it simply boosts them as water is collected.
Water catchers collect water once per minute; water pumps once every 10 seconds.

## Configuration

```json
{
  "Small Water Catchers": {
    "Minimum Boost": 0,
    "Maximum Boost": 20
  },
  "Large Water Catchers": {
    "Minimum Boost": 0,
    "Maximum Boost": 60
  },
  "Water Pumps": {
    "Minimum Boost": 0,
    "Maximum Boost": 85
  },
  "Version (Do not modify)": {
    "Major": 1,
    "Minor": 0,
    "Patch": 3
  }
}
```

- The maximum boost must be greater than (or equal to) the minimum.
- All values must be whole numbers (no decimals).

## Donate

[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/F1F8826WW)

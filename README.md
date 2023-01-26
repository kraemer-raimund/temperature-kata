# Temperature Kata

A coding kata that focuses on **encapsulation** and **simple design**.

___

## Thought Process: Designing a Type

Consider this code:

```
float temperature = 36.7f;
```

Any problems with this? Discuss with your peers.

<details>
<summary>Reveal answer</summary>

Being roughly the average body temperature (in °C) we might assume that it represents a measurement on the Celsius scale, but we might be misled. Could it be Fahrenheit? Or wouldn't the most appropriate *technical* temperature scale be Kelvin?

Let's use a clearer name:

```
float temperatureInCelsius = -300.0f;
```

That's pretty cold. Any problems with this code?

<details>
<summary>Reveal answer</summary>

Temperatures below roughly -273,15 °C are [physically impossible](https://en.wikipedia.org/wiki/Absolute_zero). Let's write some code that tells us whether a temperature is physically possible, since we don't control where the measurements come from:

```
public class TemperatureUtils {

    private static final float CELSIUS_TO_KELVIN_OFFSET = 273.15f;

    public static boolean isPhysicallyPossible(float temperatureInCelsius) {
        return toKelvin(temperatureInCelsius) >= 0.0f;
    }

    public static float toKelvin(float temperatureInCelsius) {
        return temperatureInCelsius + CELSIUS_TO_KELVIN_OFFSET;
    }
}
```

Now we can easily filter out impossible measurements, if needed. Any problems with this code?

<details>
<summary>Reveal answer</summary>

If it's a simple program that only deals with temperatures, this might be simple enough. But now imagine a more complex domain where not only temperatures, but many more concepts, are represented as a primitive type with public static methods scattered around. At that point, the difference between Java and C becomes negligible.

What are legal/meaningful operations on a temperature? Addition? Multiplication?

Imagine you had an object that represents the *concept* of a certain temperature:

* It does not imply any specific representation (Celsius, Fahrenheit, Kelvin).
* It hides the internal representation and data type.
* It has a small *surface area*, allowing only meaningful operations and preventing misuse.
* *Conversions* are replaced with *representations*.
* It is easily extensible: [There are many more temperature scales](https://en.wikipedia.org/wiki/Conversion_of_scales_of_temperature) (although much rarer in practice).

</details>

</details>

</details>

___

## Requirements

* Measurements in Celsius, Fahrenheit, and Kelvin are supported (i.e. they might be provided by different (hypothetical) external APIs on those 3 scales).
* From the caller's perspective, there are **no conversions**, only representations of the same temperature on the 3 supported scales.
* Temperatures can be formatted on all 3 supported scales.
* Immutable: No getters and setters.

  <details>
  <summary>Hint</summary>

  You might be tempted to name some read-only methods `get...()`. What's a better naming scheme in this context? Discuss! Remember: We are not *accessing internals*, but *requesting
  representations*.

  </details>

* Common temperatures (e.g. absolute zero) can be accessed exactly where they would be expected.<br>Note: You might be tempted to create a (static) class like `TemperatureConstants`. What would be a more idiomatic approach? How would you expect the standard library to do it?

  <details>
  <summary>Hint</summary>

  We are looking for static factory methods in the `Temperature` type. Note: We should probably define them as constants, since they are immutable and can thus easily be reused, but that's an implementation detail. `PUBLICLY_EXPOSING_THE_CONSTANTS` breaks encapsulation.

  </details>

___

## Example Values

You can use these values to test your implementation. You can of course [look up the formulas](https://en.wikipedia.org/wiki/Conversion_of_scales_of_temperature), but **if you don't fear a challenge**, try remapping the scales yourself based on these example values.

<details>
<summary>I want to try it myself, but I need a hint.</summary>

Remap algorithm:<br>
1. Normalize the value within the range of the current scale.
2. Place it on the target scale by multiplying it with the target scale's range.
3. Offset it by the lower of the 2 known values of the target scale.
</details>

|                          | Kelvin      | Celsius | Fahrenheit        |
|:------------------------:|:-----------:|:-----------:|:-------------:|
| Absolute zero            | 0 K         | −273.15 °C  | −459.67 °F    |
| Freezing point of water  | 273.15 K    | 0 °C        | 32 °F         |
| Boiling point of water   | 373.1339 K  | 99.9839 °C  | 211.97102 °F  |

___

© 2023 Raimund Krämer - Use with attribution.

Links to third party sites are included for convenience only and I am not responsible for their contents.

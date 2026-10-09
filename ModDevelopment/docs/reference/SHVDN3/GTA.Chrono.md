# GTA.Chrono (ScriptHookVDotNet v3)

[Back to the ScriptHookVDotNet v3 index](README.md)

> **Source:** `ScriptHookVDotNet3.dll` (file version 3.7.0.189, assembly version 3.7.0.189, 1,435,136 bytes, modified 2026-08-05, SHA-256 `0f2b8d30ebe79edd74cf364df3943afb7e6305d7453bc687503dcc7411ed5648`)  
> **Method:** public and protected types and members read from the assembly's .NET metadata with `System.Reflection.MetadataLoadContext` (the code is not run or decompiled), by `ModDevelopment/tools/ApiDocGen`.  
> **Descriptions:** `ScriptHookVDotNet3.xml` from the NuGet package `scripthookvdotnet3` 3.6.0 (nuget.org). The installed DLL is 3.7.0.189, so members added after 3.6.0 have no description.

## GameClock

static class `GTA.Chrono.GameClock`

### Properties

- `public static int Day { get; set; }`
- `public static DayOfWeek DayOfWeek { get; }`
- `public static int Hour { get; set; }`
- `public static bool IsPaused { get; set; }`
- `public static int LastTimeMinAdded { get; set; }`
- `public static int MillisecondsPerGameMinute { get; set; }`
- `public static int Minute { get; set; }`
- `public static int Month { get; set; }`
- `public static int Month0 { get; set; }`
- `public static GameClockDateTime Now { get; set; }`
- `public static int Second { get; set; }`
- `public static GameClockTime TimeOfDay { get; set; }`
- `public static GameClockDate Today { get; set; }`
- `public static int Year { get; set; }`

### Methods

- `public static void AddToCurrentTime(int hours, int minutes, int seconds)`

## GameClockDate

struct `GTA.Chrono.GameClockDate` : `IEquatable<GameClockDate>`, `IComparable<GameClockDate>`, `IComparable`, `IDatelike<GameClockDate>`

### Properties

- `public int Day { get; }`
- `public int Day0 { get; }`
- `public DayOfWeek DayOfWeek { get; }`
- `public int DayOfYear { get; }`
- `public int DayOfYear0 { get; }`
- `public bool IsLeapYear { get; }`
- `public IsoDayOfWeek IsoDayOfWeek { get; }`
- `public int Month { get; }`
- `public int Month0 { get; }`
- `public int Year { get; }`

### Methods

- `public GameClockDate AddMonths(long months)`
- `public GameClockDateTime AndHms(int hour, int minute, int second)`
- `public GameClockDateTime AndTime(GameClockTime time)`
- `public int CompareTo(GameClockDate value)`
- `public int CompareTo(object obj)`
- `public void Deconstruct(out int year, out int month, out int day)`
- `public bool Equals(GameClockDate value)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public GameClockDuration SignedDurationSince(GameClockDate value)`
- `public GameClockDate SubtractMonths(long months)`
- `public virtual string ToString()`
- `public bool TryAdd(GameClockDuration duration, out GameClockDate date)`
- `public bool TryAddMonths(long months, out GameClockDate date)`
- `public bool TrySubtract(GameClockDuration duration, out GameClockDate date)`
- `public bool TrySubtractMonths(long months, out GameClockDate date)`
- `public GameClockDate WithDay(int day)`
- `public GameClockDate WithDay0(int day0)`
- `public GameClockDate WithDayOfYear(int dayOfYear)`
- `public GameClockDate WithDayOfYear0(int dayOfYear0)`
- `public GameClockDate WithMonth(int month)`
- `public GameClockDate WithMonth0(int month0)`
- `public GameClockDate WithYear(int year)`
- `public int YearsSince(GameClockDate other)`
- `public static GameClockDate FromIsoWeekDate(int year, int week, IsoDayOfWeek dayOfWeek)`
- `public static GameClockDate FromOrdinalDate(int year, int ordinal)`
- `public static GameClockDate FromSystemDateTime(DateTime dateTime)`
- `public static GameClockDate FromYmd(int year, int month, int day)`
- `public static GameClockDate op_Addition(GameClockDate date, GameClockDuration duration)`
- `public static bool op_Equality(GameClockDate left, GameClockDate right)`
- `public static bool op_GreaterThan(GameClockDate left, GameClockDate right)`
- `public static bool op_GreaterThanOrEqual(GameClockDate left, GameClockDate right)`
- `public static bool op_Inequality(GameClockDate left, GameClockDate right)`
- `public static bool op_LessThan(GameClockDate left, GameClockDate right)`
- `public static bool op_LessThanOrEqual(GameClockDate left, GameClockDate right)`
- `public static GameClockDuration op_Subtraction(GameClockDate d1, GameClockDate d2)`
- `public static GameClockDate op_Subtraction(GameClockDate date, GameClockDuration duration)`
- `public static bool TryFromIsoWeekDate(int year, int week, IsoDayOfWeek dayOfWeek, out GameClockDate date)`
- `public static bool TryFromOrdinalDate(int year, int ordinal, out GameClockDate date)`
- `public static bool TryFromYmd(int year, int month, int day, out GameClockDate date)`

### Fields

- `public static readonly GameClockDate MaxValue`
- `public static readonly GameClockDate MinValue`

## GameClockDateTime

struct `GTA.Chrono.GameClockDateTime` : `IEquatable<GameClockDateTime>`, `IComparable<GameClockDateTime>`, `IComparable`, `IDatelike<GameClockDateTime>`, `ITimelike<GameClockDateTime>`

### Constructors

- `public GameClockDateTime(GameClockDate date, GameClockTime time)`

### Properties

- `public GameClockDate Date { get; }`
- `public int Day { get; }`
- `public int Day0 { get; }`
- `public DayOfWeek DayOfWeek { get; }`
- `public int DayOfYear { get; }`
- `public int DayOfYear0 { get; }`
- `public int Hour { get; }`
- `public ValueTuple<bool, int> Hour12 { get; }`
- `public IsoDayOfWeek IsoDayOfWeek { get; }`
- `public int Minute { get; }`
- `public int Month { get; }`
- `public int Month0 { get; }`
- `public int Second { get; }`
- `public int SecondsFromMidnight { get; }`
- `public GameClockTime Time { get; }`
- `public int Year { get; }`

### Methods

- `public GameClockDateTime AddMonths(long months)`
- `public int CompareTo(GameClockDateTime value)`
- `public int CompareTo(object obj)`
- `public void Deconstruct(out GameClockDate date, out GameClockTime time)`
- `public bool Equals(GameClockDateTime value)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public bool GetHour12(out int hour)`
- `public GameClockDuration SignedDurationSince(GameClockDateTime value)`
- `public GameClockDateTime SubtractMonths(long months)`
- `public virtual string ToString()`
- `public bool TryAdd(GameClockDuration duration, out GameClockDateTime dateTime)`
- `public bool TryAddMonths(long months, out GameClockDateTime dateTime)`
- `public bool TrySubtract(GameClockDuration duration, out GameClockDateTime dateTime)`
- `public bool TrySubtractMonths(long months, out GameClockDateTime dateTime)`
- `public GameClockDateTime WithDay(int day)`
- `public GameClockDateTime WithDay0(int day0)`
- `public GameClockDateTime WithDayOfYear(int dayOfYear)`
- `public GameClockDateTime WithDayOfYear0(int dayOfYear0)`
- `public GameClockDateTime WithHour(int hour)`
- `public GameClockDateTime WithMinute(int minute)`
- `public GameClockDateTime WithMonth(int month)`
- `public GameClockDateTime WithMonth0(int month0)`
- `public GameClockDateTime WithSecond(int second)`
- `public GameClockDateTime WithYear(int year)`
- `public static GameClockDateTime FromSystemDateTime(DateTime dateTime)`
- `public static GameClockDateTime op_Addition(GameClockDateTime dateTime, GameClockDuration duration)`
- `public static bool op_Equality(GameClockDateTime left, GameClockDateTime right)`
- `public static bool op_GreaterThan(GameClockDateTime left, GameClockDateTime right)`
- `public static bool op_GreaterThanOrEqual(GameClockDateTime left, GameClockDateTime right)`
- `public static bool op_Inequality(GameClockDateTime left, GameClockDateTime right)`
- `public static bool op_LessThan(GameClockDateTime left, GameClockDateTime right)`
- `public static bool op_LessThanOrEqual(GameClockDateTime left, GameClockDateTime right)`
- `public static GameClockDuration op_Subtraction(GameClockDateTime dt1, GameClockDateTime dt2)`
- `public static GameClockDateTime op_Subtraction(GameClockDateTime dateTime, GameClockDuration duration)`

### Fields

- `public static readonly GameClockDateTime MaxValue`
- `public static readonly GameClockDateTime MinValue`

## GameClockDuration

struct `GTA.Chrono.GameClockDuration` : `IEquatable<GameClockDuration>`, `IComparable<GameClockDuration>`, `IComparable`

### Properties

- `public int Hours { get; }`
- `public int Minutes { get; }`
- `public int Seconds { get; }`
- `public double TotalDays { get; }`
- `public double TotalHours { get; }`
- `public double TotalMinutes { get; }`
- `public double TotalWeeks { get; }`
- `public long WholeDays { get; }`
- `public long WholeHours { get; }`
- `public long WholeMinutes { get; }`
- `public long WholeSeconds { get; }`
- `public long WholeWeeks { get; }`

### Methods

- `public GameClockDuration Abs()`
- `public int CompareTo(GameClockDuration value)`
- `public int CompareTo(object obj)`
- `public bool Equals(GameClockDuration value)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public virtual string ToString()`
- `public static GameClockDuration FromDays(long days)`
- `public static GameClockDuration FromHours(long hours)`
- `public static GameClockDuration FromMinutes(long minutes)`
- `public static GameClockDuration FromSeconds(long seconds)`
- `public static GameClockDuration FromTimeSpan(TimeSpan timeSpan)`
- `public static GameClockDuration FromWeeks(long weeks)`
- `public static GameClockDuration op_Addition(GameClockDuration d1, GameClockDuration d2)`
- `public static double op_Division(GameClockDuration d1, GameClockDuration d2)`
- `public static GameClockDuration op_Division(GameClockDuration duration, double divisor)`
- `public static GameClockDuration op_Division(GameClockDuration duration, long divisor)`
- `public static bool op_Equality(GameClockDuration left, GameClockDuration right)`
- `public static bool op_GreaterThan(GameClockDuration left, GameClockDuration right)`
- `public static bool op_GreaterThanOrEqual(GameClockDuration left, GameClockDuration right)`
- `public static bool op_Inequality(GameClockDuration left, GameClockDuration right)`
- `public static bool op_LessThan(GameClockDuration left, GameClockDuration right)`
- `public static bool op_LessThanOrEqual(GameClockDuration left, GameClockDuration right)`
- `public static GameClockDuration op_Multiply(GameClockDuration duration, double factor)`
- `public static GameClockDuration op_Multiply(GameClockDuration duration, long factor)`
- `public static GameClockDuration op_Multiply(double factor, GameClockDuration duration)`
- `public static GameClockDuration op_Multiply(long factor, GameClockDuration duration)`
- `public static GameClockDuration op_Subtraction(GameClockDuration d1, GameClockDuration d2)`
- `public static GameClockDuration op_UnaryNegation(GameClockDuration d)`
- `public static GameClockDuration op_UnaryPlus(GameClockDuration d)`

### Fields

- `public static readonly GameClockDuration MaxValue`
- `public static readonly GameClockDuration MinValue`
- `public static readonly GameClockDuration Zero`

## GameClockTime

struct `GTA.Chrono.GameClockTime` : `IEquatable<GameClockTime>`, `IComparable<GameClockTime>`, `IComparable`, `ITimelike<GameClockTime>`

### Properties

- `public int Hour { get; }`
- `public ValueTuple<bool, int> Hour12 { get; }`
- `public int Minute { get; }`
- `public int Second { get; }`
- `public int SecondsFromMidnight { get; }`

### Methods

- `public int CompareTo(GameClockTime value)`
- `public int CompareTo(object obj)`
- `public void Deconstruct(out int hour, out int minute, out int second)`
- `public bool Equals(GameClockTime value)`
- `public virtual bool Equals(object obj)`
- `public virtual int GetHashCode()`
- `public bool GetHour12(out int hour)`
- `public GameClockTime OverflowingAddSigned(GameClockDuration duration, out long wrappedDays)`
- `public GameClockTime OverflowingSubtractSigned(GameClockDuration duration, out long wrappedDays)`
- `public GameClockDuration SignedDurationSince(GameClockTime value)`
- `public virtual string ToString()`
- `public GameClockTime WithHour(int hour)`
- `public GameClockTime WithMinute(int minute)`
- `public GameClockTime WithSecond(int second)`
- `public static GameClockTime FromHms(int hour, int minute, int second)`
- `public static GameClockTime FromSecondsFromMidnight(int seconds)`
- `public static GameClockTime op_Addition(GameClockTime time, GameClockDuration duration)`
- `public static bool op_Equality(GameClockTime left, GameClockTime right)`
- `public static bool op_GreaterThan(GameClockTime left, GameClockTime right)`
- `public static bool op_GreaterThanOrEqual(GameClockTime left, GameClockTime right)`
- `public static bool op_Inequality(GameClockTime left, GameClockTime right)`
- `public static bool op_LessThan(GameClockTime left, GameClockTime right)`
- `public static bool op_LessThanOrEqual(GameClockTime left, GameClockTime right)`
- `public static GameClockTime op_Subtraction(GameClockTime time, GameClockDuration duration)`
- `public static GameClockDuration op_Subtraction(GameClockTime t1, GameClockTime t2)`

### Fields

- `public static readonly GameClockTime MaxValue`
- `public static readonly GameClockTime MinValue`

## IDatelike<T>

interface `GTA.Chrono.IDatelike`1`

### Properties

- `public int Day { get; }`
- `public int Day0 { get; }`
- `public DayOfWeek DayOfWeek { get; }`
- `public int DayOfYear { get; }`
- `public int DayOfYear0 { get; }`
- `public IsoDayOfWeek IsoDayOfWeek { get; }`
- `public int Month { get; }`
- `public int Month0 { get; }`
- `public int Year { get; }`

### Methods

- `public T WithDay(int day)`
- `public T WithDay0(int day0)`
- `public T WithDayOfYear(int dayOfYear)`
- `public T WithDayOfYear0(int dayOfYear0)`
- `public T WithMonth(int month)`
- `public T WithMonth0(int month0)`
- `public T WithYear(int year)`

## InvalidInternalMonthOfGameClockException

class `GTA.Chrono.InvalidInternalMonthOfGameClockException` : `Exception`, `ISerializable`, `_Exception`

### Properties

- `public int Month { get; }`
- `public int Month0 { get; }`

### Methods

- `public virtual void GetObjectData(SerializationInfo info, StreamingContext context)`

## IsoDayOfWeek

enum `GTA.Chrono.IsoDayOfWeek`

| Name | Value |
| --- | --- |
| `Monday` | 0 |
| `Tuesday` | 1 |
| `Wednesday` | 2 |
| `Thursday` | 3 |
| `Friday` | 4 |
| `Saturday` | 5 |
| `Sunday` | 6 |

## ITimelike<T>

interface `GTA.Chrono.ITimelike`1`

### Properties

- `public int Hour { get; }`
- `public ValueTuple<bool, int> Hour12 { get; }`
- `public int Minute { get; }`
- `public int Second { get; }`
- `public int SecondsFromMidnight { get; }`

### Methods

- `public bool GetHour12(out int hour)`
- `public T WithHour(int hour)`
- `public T WithMinute(int minute)`
- `public T WithSecond(int second)`

## YearFlags

struct `GTA.Chrono.YearFlags`


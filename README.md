# Pharmacy Refill Practice (C#)

Small C# practice exercises built around long-term care pharmacy refill scenarios: refill eligibility checks and delivery batch assignment.

## Background

I work daily in long-term care pharmacy operations, handling refill requests, order entry, and delivery batching. This repo is where I practice C#/.NET fundamentals using scenarios drawn from that domain, real logic like "is this refill too soon" and "which delivery batch does this go in," written as simple, focused exercises rather than a full application.

## What's here

- **Patient class** — basic patient/medication record (name, medication, days since last fill)
- **Refill eligibility logic** — a `IsRefillTooSoon()` check based on days since last fill
- **Delivery batch assignment** — assigns a patient to a delivery batch (`OnePM` or `Midnight`) based on time of day
- **LINQ filtering** — filtering a list of patients down to those eligible for refill

## Why

Practicing C#/.NET fundamentals using pharmacy-domain scenarios, building toward a larger project over time.

## Tech

- C# / .NET
- LINQ

## Status

Actively adding to this as I keep practicing. Next planned additions: reject-code modeling, expanded eligibility rules, basic console interaction.

This is a test task!
Classes:
> Obstacle, IObstacle - class for obstacles, provide transform, collider and if this object is visible
> DistanceChecker - class for proximity calculations (Note, editor camera make objects visible!)
> MetricsPanel - class for UI panel that updates data
> MetricsLine - class for line on the panel, has prefix before value and sets text
> VehicleMetrics - class that gathers data from different classes
> CsvMetricsWriter - class that saves data to the file (path is /Files)
> PlayerCarMetricsProvider - class that has static field of player metrics. It would be much better to use DI

export interface DataPoint {
    x: Number       // Year
    y: Number       // Data value
    label: String   // Year in string format
}

export interface LineData {
    // Angular charts config data
    type: String
    showInLegend: Boolean

    name: String            // Team or player name
    dataPoints: DataPoint[] // Data for each year
}

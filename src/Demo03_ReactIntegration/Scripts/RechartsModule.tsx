import { registerReactControl } from 'dotvvm-jscomponent-react';

import { BarChartWrapper } from "./BarChartWrapper";

export default (context: any) => ({
    $controls: {
        BarChart: registerReactControl(BarChartWrapper, {
            context,
            serieClick() { /* default empty method */ }
        })
    }
})
import * as React from 'react';
import { BarChart, XAxis, YAxis, CartesianGrid, Bar } from 'recharts';

// react component
export function BarChartWrapper(props: any) {
    return (
        <BarChart data={props.data} width={800} height={400}>
            <XAxis dataKey={props.xLabel} />
            <YAxis />
            <CartesianGrid stroke="#f5f5f5" />
            {
                props.serieNames.split(',').map((serieName, index) =>
                    <Bar dataKey={serieName}
                         fill={props.serieColors.split(',')[index]}
                         onClick={(_) => props.serieClick(serieName)}
                         key={index} />)
            }
        </BarChart>
    );
}
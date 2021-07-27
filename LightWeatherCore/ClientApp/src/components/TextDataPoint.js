import React from 'react';

const TextDataPoint = ({ dataPointTitle, dataPointData, units }) => {
  return (
    <div className="text-data-point">
      {dataPointTitle}: {dataPointData}
      {units}
    </div>
  );
};

export default TextDataPoint;

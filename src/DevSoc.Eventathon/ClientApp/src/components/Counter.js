import React, { useCallback, useState } from 'react';

export const Counter = () => {
  const [count, setCount] = useState(0);
  const incrementCounter = useCallback(() => setCount(count + 1), [count, setCount]);

  return (
    <div>
      <h1>Counter</h1>

      <p>This is a simple example of a React component.</p>

      <p aria-live="polite">Current count: <strong>{count}</strong></p>

      <button className="btn btn-primary" onClick={incrementCounter}>Increment</button>
    </div>
  );
}

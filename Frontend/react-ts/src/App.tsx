import { Routes, Route } from 'react-router-dom';

function Home() { return <h1 className="text-3xl font-bold p-8">Home</h1>; }
function About() { return <h1 className="text-3xl font-bold p-8">About</h1>; }
function NotFound() { return <h1 className="text-3xl font-bold p-8">404</h1>; }

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/about" element={<About />} />
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
}
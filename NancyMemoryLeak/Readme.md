### Memory Leak in Nancy

## Steps
1. Run NancyMemoryLeak.exe
2. Run [TinyGet](https://github.com/shchahrykovich/TinyGet): TinyGet.exe -srv:localhost -uri:/v1/feeds -threads:10 -loop:20000 -port:5000 -status:200
3. Open [NancyCounters.PerfmonCfg](NancyCounters.PerfmonCfg)
4. Take a memory dump
5. Close TinyGet and NancyMemoryLeak, Ctrl-C
6. Open the dump in WinDbg and execute:
    1. .loadby sos clr
    2. !DumpHeap -stat
    3. !DumpHeap /d -mt 00007ffbdfa0ed98
    4. !GCRoot 000000b4801535d8
    5. !DumpObj 000000b48012bda0
7. Open source code of [NancyEngine](https://github.com/NancyFx/Nancy/blob/36b213b0da30edbdc4e5ed7b6c9085d6c8332f16/src/Nancy/NancyEngine.cs)
8. Review [fix](https://github.com/NancyFx/Nancy/commit/7d70fed4c1dbd9bd530564c4e06a178ed2e19ef6)
8. Find usages of engineDisposedCts field
9. Close WinDbg


## References
https://lowleveldesign.wordpress.com/2015/11/30/catch-in-cancellationtokensource
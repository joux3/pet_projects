require_relative 'regex_to_postfix'
require_relative 'nfa_engine'
require 'benchmark'

if ARGV.size != 2
  puts "Usage: regex_matcher [regex] [input]"
  exit
end
include NFA
postfix = RegexParser.new.parse(ARGV[0])
matcher = automata_from_postfix(postfix)

rresult, result = 0, 0
Benchmark.bm(10) do |x|
  x.report("my regex") {result = matcher.run_input(ARGV[1])}
  x.report("ruby's") {rresult = /#{ARGV[0]}/ =~ ARGV[1]}
end
puts "result: #{result}"
puts "rresult: #{result}"

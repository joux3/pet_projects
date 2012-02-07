require_relative "nfa_engine"
class RegexParser
  include NFA
  # operator precedence
  OP = {ALTERNATION => -1, ZERO_OR_ONE => 1, ZERO_OR_MORE => 1, ONE_OR_MORE => 1, nil => -1, '(' => -5, CONCAT => 0}
  OPER_MAPPINGS = {"?" => ZERO_OR_ONE, "*" => ZERO_OR_MORE, "+" => ONE_OR_MORE, "|" => ALTERNATION, CONCAT => CONCAT}
  def parse(input)
    output = []
    operators = []
    add_concats(input).each {|c|
      case c
      when ")"
        while true 
          op = operators.pop
          raise "Unmatched )!" if op.nil?
          break if op == "("
          output.push(op)
        end
      when "("
        operators << c
      when "*", "?", "+", "|", CONCAT
        if OP[OPER_MAPPINGS[c]] <= OP[operators.last]
          output.push(operators.pop)
        end
        operators.push(OPER_MAPPINGS[c])
      else
        output << c
      end
    }
    operators.reverse.each {|operator| output.push(operator)}
    output
  end

  # adds concats
  def add_concats(input)
    output = []
    input[0..input.size-2].chars.each_with_index{|c, i|
      c2 = input[i+1]
      output << c
      if (c != "(" and c != "|") and c2 != ")" and (!OPER_MAPPINGS.include?(c2) || c2 == "(")
        output << CONCAT
      end
    }
    output + [input[-1]]
  end
end

if __FILE__ == $0
  puts RegexParser.new.add_concats(ARGV[0]).inspect
  puts RegexParser.new.parse(ARGV[0]).inspect
end

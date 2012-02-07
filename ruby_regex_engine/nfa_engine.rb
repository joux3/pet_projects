module NFA
  class State
    attr_reader :split
    # initializer accepts a string array or a Proc that returns a boolean for string
    def initialize(chars, split = false)
      @split = split
      chars = [chars] if chars.is_a?(String)
      @next_states = []
      @chars = chars
    end

    def accepts_char?(c)
      if @chars.is_a?(Array)
        @chars.include?(c)
      else
        @chars.call(c)
      end
    end

    def connect_state(s)
      @next_states << s
    end

    def next_states
      result = []
      @next_states.select {|s|
        if s.split
          result += s.next_states
        else
          result << s 
        end
      }
      result
    end

    def to_s
      "s(#{@chars}#{@split ? ", split" : ""}, #{@next_states.inspect})"
    end
  end
  
  MATCH_STATE = State.new([])

  class Automata
    def initialize(start_state)
      @start_state = start_state
    end

    def run_input(input)
      current_states = [@start_state]
      current_states = @start_state.next_states if @start_state.split # ugly
      len = input.size
      while (!current_states.empty? and input.size > 0)
        #puts "'#{input}': #{current_states}"
        next_states = []
        char = input[0, 1]
        input = input[1, len]
        current_states.select {|s| s.accepts_char?(char)}.each {|cur_state|
          next_states = (next_states + cur_state.next_states).uniq
        }
        current_states = next_states
      end
      #puts "'#{input}': #{current_states}"
      current_states.include?(MATCH_STATE)
    end
  end

  CONCAT, ALTERNATION, ZERO_OR_ONE, ZERO_OR_MORE, ONE_OR_MORE = "CONCAT", "ALT", "Z_0", "Z_*", "1_+"
  # postfix must be an array of tokens
  def automata_from_postfix(postfix)
    stack = []

    def patch(outlist, state)
      outlist.each {|o| o.connect_state(state)}
    end

    postfix.each {|t|
      case t
      when CONCAT
        e2, e1 = stack.pop, stack.pop
        patch(e1[1], e2[0])
        stack << [e1[0], e2[1]]
      when ALTERNATION
        e2, e1 = stack.pop, stack.pop
        s = State.new([], true)
        s.connect_state(e1[0])
        s.connect_state(e2[0])
        stack << [s, e1[1] + e2[1]]
      when ZERO_OR_ONE
        e = stack.pop
        s = State.new([], true)
        s.connect_state(e[0])
        stack << [s, e[1] + [s]]
      when ZERO_OR_MORE
        e = stack.pop
        s = State.new([], true)
        s.connect_state(e[0])
        patch(e[1], s)
        stack << [s, [s]]
      when ONE_OR_MORE
        e = stack.pop
        s = State.new([], true)
        s.connect_state(e[0])
        patch(e[1], s)
        stack << [e[0], [s]]
      else 
        s = State.new(t)
        stack << [s, [s]]
      end 
    }
    e = stack.pop
    patch(e[1], MATCH_STATE)
    Automata.new(e[0])
  end
end

if __FILE__ == $0
  include NFA
 # s = automata_from_postfix(["a", "b", "c", ALTERNATION, CONCAT, "z", ZERO_OR_MORE, CONCAT])
  s = automata_from_postfix(["a", ONE_OR_MORE])
  #puts s.inspect
  puts("input accepted: #{s.run_input(ARGV[0])}")
end
